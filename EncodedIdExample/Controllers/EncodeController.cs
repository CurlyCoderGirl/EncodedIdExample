using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EncodedIdExample.Policy.Dtos;
using EncodedIdExample.Policy.Utils;

namespace EncodedIdExample.Controllers
{
    public class EncodeController : ApiController
    {

      [HttpGet]
      [Route("API/V1/Build")]
      public HttpResponseMessage GetBuild(string buildId)
      {
        int id = 0;
        try
        {
           string tempId = EncryptionUtils.Decrypt(buildId);
          id = Int32.Parse(tempId);
        }
        catch (Exception e)
        {
          //Do something with the error, whether it be logging or an email.
        }

        //Do your sql code with the id

        return Request.CreateResponse(HttpStatusCode.OK, id); // return your build string here. For test purposes I'm just going to return the parsed id.
    }

      [Route("API/V1/CreateShareLink")]
      [HttpPost]
      public HttpResponseMessage CreateShareLink(Build build)
      {
        string encrypt = EncryptionUtils.Encrypt(build.BuildId.ToString());

        return Request.CreateResponse(HttpStatusCode.OK,
          $"https://localhost.encodeidexample.codergirl.com?id=" + encrypt);
      }


    }
}
