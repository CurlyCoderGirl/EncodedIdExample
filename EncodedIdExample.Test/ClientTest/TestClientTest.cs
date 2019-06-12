using System;
using EncodedIdExample.Client.Clients;
using EncodedIdExample.Policy.Dtos;
using NUnit.Framework;

namespace EncodedIdExample.Test.ClientTest
{
  public class TestClientTest
  {
    public TestClientTest()
    {
    }


    [Test]
    public void CreateShareLink()
    {
      TestClient client = new TestClient("http://127.0.0.1:8080/");
      Build build = new Build()
      {
        BuildId = 125
      };

      string shareUrl = client.CreateShareLink(build);
      Console.WriteLine(shareUrl);
      Console.WriteLine(shareUrl);
    }
  }
}
