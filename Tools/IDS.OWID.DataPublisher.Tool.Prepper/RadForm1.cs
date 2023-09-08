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
    private JsonSerializerSettings _options = new JsonSerializerSettings
    {
      NullValueHandling = NullValueHandling.Ignore,
      DefaultValueHandling = DefaultValueHandling.Ignore,
      Formatting = Formatting.Indented
    };

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
      Hide();

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
      WriteIndex(columns, pubDir, publicData);

      var form = new PivotHelper(columns, pubDir);
      form.ShowDialog();

      Close();
    }

    private void WriteIndex(Dictionary<string, string> columns, string dir, Dictionary<string, object>[] data)
    {
      var index = new Dictionary<string, HashSet<string>>();
      foreach (var x in columns)
      {
        var key = x.Value;
        var val = new HashSet<string>();
        foreach (var y in data)
        {
          if (y.ContainsKey(key))
            val.Add(y[key]?.ToString());
        }
        index.Add(x.Key, val);
      }
      File.WriteAllText(Path.Combine(dir, "index.json"), JsonConvert.SerializeObject(index));
    }

    private void WriteData(string label, Dictionary<string, string> columns, string dir, Dictionary<string, object>[] data)
    {
      File.WriteAllText(Path.Combine(dir, "data.json"), JsonConvert.SerializeObject(data, _options));
      File.WriteAllText(Path.Combine(dir, "schema.json"), JsonConvert.SerializeObject(GetSchema(columns, data)));

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
            csv.WriteField(item.ContainsKey(c.Value) ? item[c.Value] : null);
          csv.NextRecord();
        }
      }
      #endregion

      #region ZIP    
      using (var fs = new FileStream(Path.Combine(dir, "data.zip"), FileMode.Create, FileAccess.Write))
      using (var zip = new ZipOutputStream(fs))
      {
        WriteData_PutJson(zip, dir, columns, data);
        PutEntry(zip, "data.tsv", Path.Combine(dir, "data.tsv"));
        if (!string.IsNullOrEmpty(_readme))
          PutEntry(zip, "README.md", _readme);
        if (!string.IsNullOrEmpty(_license))
          PutEntry(zip, "LICENSE", _license);
      }
      #endregion
    }

    private void WriteData_PutJson(ZipOutputStream zip, string dir, Dictionary<string, string> columns, Dictionary<string, object>[] data)
    {
      var reverse = columns.ToDictionary(x => x.Value, x => x.Key);
      var resolved = data.Select(x => x.ToDictionary(y => reverse[y.Key], y => y.Value)).ToArray();
      var temp = Path.Combine(dir, "temp.json");
      File.WriteAllText(temp, JsonConvert.SerializeObject(resolved, _options));
      PutEntry(zip, "data.json", temp);
      File.Delete(temp);
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

    private Dictionary<string, string>[] GetSchema(Dictionary<string, string> columns, Dictionary<string, object>[] data)
    {
      var res = new Dictionary<string, Dictionary<string, string>>();

      foreach (var sample in data)
        foreach (var x in sample)
        {
          var name = x.Key;
          if (res.ContainsKey(name))
            continue;

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
          res.Add(name, obj);
        }

      return res.Values.ToArray();
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
  }
}
