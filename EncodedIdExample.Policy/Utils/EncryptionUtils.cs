using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncodedIdExample.Policy.Utils
{
  public class EncryptionUtils
  {
    private static string _key = "test"; //4 characters only

    public static string Encrypt(string encryptString)
    {
      byte[] encrypt;
      using (RijndaelManaged rijndael = new RijndaelManaged())
      {
        rijndael.Key = Encoding.UTF32.GetBytes(_key);
        rijndael.Padding = PaddingMode.ISO10126;
        rijndael.BlockSize = 192;
        rijndael.Mode = CipherMode.ECB;
        using (ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV))
        {
          using (MemoryStream msEncrypt = new MemoryStream())
          {
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
              using (StreamWriter stream = new StreamWriter(csEncrypt))
              {
                stream.Write(encryptString);
              }

              encrypt = msEncrypt.ToArray();
            }
          }
        }
      }
      

      return Convert.ToBase64String(encrypt);
    }

    public static string Decrypt(string decryptString)
    {
      string text = null;
      using (RijndaelManaged rijndael = new RijndaelManaged())
      {
        byte[] decryptBytes = Convert.FromBase64String(decryptString);
        rijndael.Key = Encoding.UTF32.GetBytes(_key);
        rijndael.Padding = PaddingMode.ISO10126;
        rijndael.BlockSize = 192;
        rijndael.Mode = CipherMode.ECB;
        using (ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV))
        {
          using (MemoryStream msDecrypt = new MemoryStream(decryptBytes))
          {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
              using (StreamReader stream = new StreamReader(csDecrypt))
              {
                text = stream.ReadToEnd();
              }
            }
          }
        }
      }

      return text;
    }
  }
}