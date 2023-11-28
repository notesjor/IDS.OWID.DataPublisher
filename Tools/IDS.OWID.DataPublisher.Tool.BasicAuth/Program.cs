using System.Security.Cryptography;
using System.Text;

namespace IDS.OWID.DataPublisher.Tool.BasicAuth
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("IDS.OWID.DataPublisher.Tool.BasicAuth (c) 2023 by J. O. Rüdiger");

      Console.Write("Password: ");
      var psw = QuickHash(Console.ReadLine());
      var salt = QuickHash(Guid.NewGuid().ToString("N"));

      var psw_salted = QuickHash(salt + psw);

      File.WriteAllText("basic_auth.json", JsonConvert.SerializeObject(new BasicAuth { Salt = salt, SaltedPassword = psw_salted }), Encoding.UTF8);

      Console.WriteLine("File: basic_auth.json created!");
      Console.ReadLine();
    }
    
    private class BasicAuth
    {
      public string Salt { get; set; }
      public string SaltedPassword { get; set; }
    }

    private static string QuickHash(string key)
    {
      using (var hash = SHA512.Create())
        return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(key)));
    }
  }
}
