using CsvHelper;
using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IDS.OWID.DataPublisher.Tool.Prepper
{
  public partial class RadForm1 : Telerik.WinControls.UI.RadForm
  {
    private string _path;
    private HashSet<string> _keys;
    private List<Dictionary<string, object>> _data;
    private string _license;
    private string _readme;
    private string _index => drop_index.SelectedItem.Text;

    public RadForm1()
    {
      InitializeComponent();
    }

    private void btn_open_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = "JSON-Datei (*.json)|*.json",
        Title = "JSON-Datei öffnen",
        Multiselect = false
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _path = ofd.FileName;
      _keys = new HashSet<string>();
      _data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(File.ReadAllText(_path, Encoding.UTF8));
      foreach (var item in _data)
        foreach (var key in item.Keys)
          _keys.Add(key);

      foreach (var item in _keys)
        list.Items.Add(item);

      list.SelectedIndex = 0;

      datakey.Text = GetDataKey(_path);
    }

    private string GetDataKey(string path)
    {
      using (var md5 = System.Security.Cryptography.MD5.Create())
      {
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(path));
        return string.Join("", hash.Select(x => x.ToString("X2")));
      }
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      btn_export.Enabled = false;
      var pubDir = Path.GetDirectoryName(_path);
      var name = Path.GetFileNameWithoutExtension(_path);

      var columns = GetColumns();
      var privateData = _data.Select(x => x.ToDictionary(y => columns[y.Key], y => y.Value)).ToArray();

      var secDir = Path.Combine(pubDir, datakey.Text);
      if (!Directory.Exists(secDir))
        Directory.CreateDirectory(secDir);

      WriteData("full", columns, secDir, privateData);

      var hideKeys = new HashSet<string>(list.Items.Where(x => x.CheckState == Telerik.WinControls.Enumerations.ToggleState.On).Select(x => x.Text));
      var publicData = _data.Select(x => x.Where(y => !hideKeys.Contains(y.Key)).ToDictionary(y => columns[y.Key], y => y.Value)).ToArray();
      columns = columns.Where(x => !hideKeys.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);

      WriteData("public", columns, pubDir, publicData);
      if (chk_index.Checked)
        WriteIndex(columns, pubDir, publicData);

      Hide();

      var form = new PivotHelper(columns, pubDir);
      form.ShowDialog();

      Close();
    }

    private void WriteIndex(Dictionary<string, string> columns, string dir, Dictionary<string, object>[] publicData)
    {
      var hashset = new HashSet<string>();
      foreach (var item in publicData)
        hashset.Add(item[columns[_index]].ToString());
      File.WriteAllText(Path.Combine(dir, "index.json"), JsonConvert.SerializeObject(hashset));
    }

    private void WriteData(string label, Dictionary<string, string> columns, string dir, Dictionary<string, object>[] data)
    {
      File.WriteAllText(Path.Combine(dir, "data.json"), JsonConvert.SerializeObject(data));
      File.WriteAllText(Path.Combine(dir, "schema.json"), JsonConvert.SerializeObject(GetSchema(columns, data.First())));

      #region CSV
      var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
      {
        Delimiter = "\t",
        Encoding = Encoding.UTF8,
        TrimOptions = CsvHelper.Configuration.TrimOptions.Trim
      };

      using (var fs = new FileStream(Path.Combine(dir, "data.tsv"), FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      using (var csv = new CsvWriter(writer, config))
      {
        foreach (var c in columns)
          csv.WriteField(c.Key);
        csv.NextRecord();

        foreach (var item in data)
        {
          foreach (var c in columns)
            csv.WriteField(item[c.Value]);
          csv.NextRecord();
        }
      }
      #endregion

      #region ZIP    
      using (var fs = new FileStream(Path.Combine(dir, "data.zip"), FileMode.Create, FileAccess.Write))
      using (var zip = new ZipOutputStream(fs))
      {
        PutEntry(zip, "data.json", Path.Combine(dir, "data.json"));
        PutEntry(zip, "data.tsv", Path.Combine(dir, "data.tsv"));
        if (!string.IsNullOrEmpty(_readme))
          PutEntry(zip, "README.md", _readme);
        if (!string.IsNullOrEmpty(_license))
          PutEntry(zip, "LICENSE", _license);
      }
      #endregion
    }

    private void PutEntry(ZipOutputStream zip, string label, string path)
    {
      var buffer = new byte[4096];
      zip.PutNextEntry(new ZipEntry(label));
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
        int sourceBytes;
        do
        {
          sourceBytes = fs.Read(buffer, 0, buffer.Length);
          zip.Write(buffer, 0, sourceBytes);
        } while (sourceBytes > 0);
      }
    }

    private Dictionary<string, string>[] GetSchema(Dictionary<string, string> columns, Dictionary<string, object> sample)
    {
      var res = new List<Dictionary<string, string>>();

      foreach (var x in sample)
      {
        var name = x.Key;
        var type = x.Value?.GetType();

        var obj = new Dictionary<string, string>{
          { "allowFiltering", "true" },
          { "allowSorting", "true" },
          { "allowSortingBySummary", "true" }
        };

        if (type == typeof(int))
          obj.Add("dataType", "number");
        else if (type == typeof(double))
          obj.Add("dataType", "number");
        else if (type == typeof(DateTime))
          obj.Add("dataType", "date");
        else
          obj.Add("dataType", "string");

        obj.Add("dataField", name);
        obj.Add("caption", columns.First(x => x.Value == name).Key);
        res.Add(obj);
      }

      return res.ToArray();
    }

    private Dictionary<string, string> GetColumns()
    {
      var res = new Dictionary<string, string>();
      foreach (var key in _keys)
        res.Add(key, $"c{res.Count:D2}");
      return res;
    }

    private void btn_add_licence_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = "LICENSE|LICENSE",
        Title = "Lizenz öffnen",
        Multiselect = false,
        CheckFileExists = true
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _license = ofd.FileName;
      chk_licence.Checked = true;
    }

    private void btn_add_readme_Click(object sender, EventArgs e)
    {
      var ofd = new OpenFileDialog
      {
        Filter = "README.md|README.md",
        Title = "README.md öffnen",
        Multiselect = false,
        CheckFileExists = true
      };
      if (ofd.ShowDialog() != DialogResult.OK)
        return;

      _readme = ofd.FileName;
      chk_readme.Checked = true;
    }

    private void chk_index_ToggleStateChanged(object sender, StateChangedEventArgs args)
    {
      drop_index.Enabled = chk_index.Checked;

      drop_index.Items.Clear();
      foreach (var item in _keys)
        drop_index.Items.Add(item);
      drop_index.SelectedIndex = 0;
    }
  }
}
