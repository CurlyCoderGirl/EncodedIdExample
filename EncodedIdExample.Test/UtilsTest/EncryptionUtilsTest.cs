using System;
using EncodedIdExample.Policy.Utils;
using NUnit.Framework;

namespace EncodedIdExample.Test.UtilsTest
{
  public class EncryptionUtilsTest
  {

    [Test]
    public void EncryptStringTest()
    {
      string encrypt = EncryptionUtils.Encrypt("12");
      Console.WriteLine($"Encrypted Id: {encrypt}");
    }

    [Test]
    public void DecryptStringTest()
    {
      string decrypt = EncryptionUtils.Decrypt("2RICzKPdKH1yoj/yzO401R3856SM5LJp");

      Console.WriteLine(decrypt);
      Assert.IsTrue(decrypt == "12");
    }
  }
}