using EncodedIdExample.Policy.Dtos;
using RestSharp;

namespace EncodedIdExample.Client.Clients
{
  public class TestClient
  {
    private string _baseString;
    private RestClient _client;


    public TestClient(string baseString)
    {
      _baseString = baseString;
      _client = new RestClient(_baseString);
    }


    public string CreateShareLink(Build build)
    {
      RestRequest request = new RestRequest("API/V1/CreateShareLink", Method.POST);
      request.AddJsonBody(build);

      IRestResponse response = _client.Execute(request);

      return response.Content;

    }
  }
}
