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
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      btn_export.Enabled = false;
      var path = Path.GetDirectoryName(_path);
      var name = Path.GetFileNameWithoutExtension(_path);

      File.Copy(_path, Path.Combine(path, name + ".sec.json"), true);

      var hideKeys = new HashSet<string>(list.Items.Where(x => x.CheckState == Telerik.WinControls.Enumerations.ToggleState.On).Select(x => x.Text));

      foreach (var item in _data)
      {
        foreach (var k in hideKeys)
          if (item.ContainsKey(k))
            item.Remove(k);
      }

      File.WriteAllText(Path.Combine(path, name + ".pub" +
        ".json"), JsonConvert.SerializeObject(_data));
      Close();
    }
  }
}
