using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
      var path = Path.GetDirectoryName(_path);
      var name = Path.GetFileNameWithoutExtension(_path);

      var columns = GetColumns();
      var copy = _data.Select(x => x.ToDictionary(y => columns[y.Key], y => y.Value)).ToArray();

      var secDir = Path.Combine(path, datakey.Text);
      if (!Directory.Exists(secDir))
        Directory.CreateDirectory(secDir);

      File.WriteAllText(Path.Combine(secDir, "data.json"), JsonConvert.SerializeObject(copy));
      GetSchema(columns, copy.First(), out var schemaGrid, out var schemaPivot);
      File.WriteAllText(Path.Combine(secDir, "grid.schema"), JsonConvert.SerializeObject(schemaGrid));
      File.WriteAllText(Path.Combine(secDir, "pivot.schema"), JsonConvert.SerializeObject(schemaPivot));

      var hideKeys = new HashSet<string>(list.Items.Where(x => x.CheckState == Telerik.WinControls.Enumerations.ToggleState.On).Select(x => x.Text));

      copy = _data.Select(x => x.Where(y => !hideKeys.Contains(y.Key)).ToDictionary(y => columns[y.Key], y => y.Value)).ToArray();
      File.WriteAllText(Path.Combine(path, "public.json"), JsonConvert.SerializeObject(copy));
      GetSchema(columns, copy.First(), out var schemaGridPublic, out var schemaPivotPublic);
      File.WriteAllText(Path.Combine(path, "grid.schema"), JsonConvert.SerializeObject(schemaGridPublic));
      File.WriteAllText(Path.Combine(path, "pivot.schema"), JsonConvert.SerializeObject(schemaPivotPublic));
      Close();
    }

    private void GetSchema(Dictionary<string, string> columns, Dictionary<string, object> sample, out Dictionary<string, string>[] schemaGrid, out Dictionary<string, string>[] schemaPivot)
    {
      var resGrid = new List<Dictionary<string, string>>();
      var resPivot = new List<Dictionary<string, string>>();

      foreach (var item in columns)
      {
        var name = item.Value;
        if (!sample.ContainsKey(name))
          continue;
        var type = sample[name]?.GetType();

        var obj = new Dictionary<string, string> {
          { "width", "140" }
        };

        if (type == typeof(int))
          obj.Add("type", "number");
        else if (type == typeof(double))
          obj.Add("type", "number");
        else if (type == typeof(DateTime))
          obj.Add("type", "date");
        else
          obj.Add("type", "string");

        var tmpGrid = obj.ToDictionary(x => x.Key, x => x.Value);
        tmpGrid.Add("field", name);
        tmpGrid.Add("headerText", item.Key);
        resGrid.Add(tmpGrid);

        var tmpPivot = obj.ToDictionary(x => x.Key, x => x.Value);
        tmpPivot.Add("name", name);
        tmpPivot.Add("caption", item.Key);
        resPivot.Add(tmpPivot);
      }

      schemaGrid = resGrid.ToArray();
      schemaPivot = resPivot.ToArray();
    }

    private Dictionary<string, string> GetColumns()
    {
      var res = new Dictionary<string, string>();
      foreach (var key in _keys)
        res.Add(key, $"c{res.Count:D2}");
      return res;
    }
  }
}
