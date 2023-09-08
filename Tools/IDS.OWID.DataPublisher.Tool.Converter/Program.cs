using ExcelDataReader;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace IDS.OWID.DataPublisher.Tool.Converter
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

      var input = args[0];
      var empty = args.Length == 2 ? args[1] : string.Empty;

      if (input.ToLower().EndsWith(".xlsx"))
        ConvertExcel(input, empty);
    }

    #region EXCEL

    private static void ConvertExcel(string path, string empty)
    {
      var data = ConvertExcel_GetData(path, empty);

      var options = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        DefaultValueHandling = DefaultValueHandling.Ignore,
        Formatting = Formatting.Indented
      };


      File.WriteAllText(Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".json"), JsonConvert.SerializeObject(data, options), Encoding.UTF8);
    }

    private static List<Dictionary<string, object>> ConvertExcel_GetData(string path, string empty)
    {
      var data = ConvertExcel_ReadFile(path, false);
      var table = data.Tables[0];

      // Erzeugt ein Dictionary (Key = Index der Spalte / Value = Name der Spalte)
      var header = table.Rows[0].ItemArray.ToArray();
      var dic = new Dictionary<int, string>();
      for (var i = 0; i < header.Length; i++)
      {
        var head = header[i].ToString();

        // Filter um spätere Fehler zu vermeiden.
        if (string.IsNullOrEmpty(head))
          continue;
        if (dic.Any(x => x.Value == head))
          continue;

        dic.Add(i, head);
      }

      // Lese Datensätze ein
      var res = new List<Dictionary<string, object>>();
      for (var i = 1; i < table.Rows.Count; i++)
      {
        var row = table.Rows[i];
        var tmp = dic.ToDictionary(col => col.Value, col => row[col.Key]);
        res.Add(tmp
          .Where(x => x.Value != null && x.Value.ToString() != empty)
          .ToDictionary(x => x.Key, x => x.Value)
          );
      }

      return res;
    }

    private static DataSet ConvertExcel_ReadFile(string path, bool isFirstRowAsColumnNames = true)
    {
      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      using (var bs = new BufferedStream(fs))
      {
        var reader = ExcelReaderFactory.CreateReader(bs);
        return reader.AsDataSet(
          new ExcelDataSetConfiguration
          {
            UseColumnDataType = true,
            ConfigureDataTable = tableReader => new ExcelDataTableConfiguration
            {
              UseHeaderRow = false
            }
          });
      }
    }

    #endregion
  }
}