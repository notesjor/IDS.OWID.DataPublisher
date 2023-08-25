using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS.OWID.DataPublisher.Tool.Prepper
{
  public partial class PivotEntry : UserControl
  {
    private Dictionary<string, string> _columns;

    public PivotEntry(Dictionary<string, string> columns)
    {
      _columns = columns;

      InitializeComponent();

      box_x.AutoCompleteDataSource = columns.Keys.ToList();
      box_x.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

      box_y.AutoCompleteDataSource = columns.Keys.ToList();
      box_y.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

      box_v.AutoCompleteDataSource = columns.Keys.ToList();
      box_v.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    }

    private class Entry
    {
      public string label { get; set; }
      public List<Dictionary<string, string>> query { get; set; }
    }

    public string Result
    {
      get
      {
        try
        {
          var query = new List<Dictionary<string, string>>();

          foreach (var item in box_x.Text.Split(";").Select(x => x.Trim()))
          {
            if(!_columns.ContainsKey(item))
              continue;

            query.Add(new Dictionary<string, string>
            {
              { "dataField", _columns[item] },
              { "area", "column" }
            });
          }
          foreach (var item in box_y.Text.Split(";").Select(x => x.Trim()))
          {
            if (!_columns.ContainsKey(item))
              continue;

            query.Add(new Dictionary<string, string>
            {
              { "dataField", _columns[item] },
              { "area", "row" }
            });
          }
          foreach (var item in box_v.Text.Split(";").Select(x => x.Trim()))
          {
            if (!_columns.ContainsKey(item))
              continue;

            query.Add(new Dictionary<string, string>
            {
              { "dataField", _columns[item] },
              { "area", "data" },
              { "summaryType", drop_func.SelectedItem.Text }
            });
          }

          var entry = new Entry
          {
            label = txt_label.Text,
            query = query
          };

          return JsonConvert.SerializeObject(entry);
        }
        catch
        {
          return null;
        }
      }
    }
  }
}
