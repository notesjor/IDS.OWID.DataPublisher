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

      if(input.ToLower().EndsWith(".xlsx"))
        ConvertExcel(input);
    }

    #region EXCEL

    private static void ConvertExcel(string path)
    {
      var data = ConvertExcel_GetData(path);
      File.WriteAllText(Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".json"), JsonConvert.SerializeObject(data), Encoding.UTF8);
    }

    private static List<Dictionary<string, object>> ConvertExcel_GetData(string path)
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
        res.Add(dic.ToDictionary(col => col.Value, col => row[col.Key]));
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