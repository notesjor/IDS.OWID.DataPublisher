using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS.OWID.DataPublisher.Tool.Prepper
{
  public partial class PivotHelper : Telerik.WinControls.UI.RadForm
  {
    private Dictionary<string, string> _columns;
    private string _dir;

    public PivotHelper(Dictionary<string, string> columns, string dir)
    {
      InitializeComponent();

      _columns = columns;
      _dir = dir;
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      var list = new List<PivotEntry>();
      foreach (var item in panel.Controls[0].Controls)
        if (item is PivotEntry pe)
          list.Add(pe);

      var res = $"[{string.Join(",", list.Where(x=>!string.IsNullOrEmpty(x.Result)).Select(x=>x.Result))}]";
      File.WriteAllText(Path.Combine(_dir, "pivotProfiles.json"), res, Encoding.UTF8);

      Close();
    }

    private void btn_add_Click(object sender, EventArgs e)
    {
      panel.Controls.Add(new PivotEntry(_columns) { Dock = DockStyle.Top });
    }
  }
}
