using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;

namespace APIArishaEPAM.Tests
{
    [TestClass]
    public class FileUpload
    {
        [TestMethod]
        public void TestUpload()
        {
            var client = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Dropbox-API-Arg", "{\"path\":\"/upl.jpg\",\"mode\":\"add\",\"autorename\":true,\"mute\":false,\"strict_conflict\":false}");
            request.AddHeader("Authorization", "Bearer CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH");
            request.AddParameter("application/octet-stream", "<file contents here>", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string resp = response.Content.ToString();
            NUnit.Framework.Assert.AreEqual(200,(int)response.StatusCode);//status
            NUnit.Framework.Assert.AreEqual(true, resp.Contains("id:URSsRWTGmWAAAAAAAAA"));//id
            NUnit.Framework.Assert.AreEqual(true, resp.Contains("b686266b0ed8fbb70285d423e3015f34f6b0a49fbfc2ba5dda89603b07f6def8"));//content_hash
            NUnit.Framework.Assert.AreEqual(true, resp.Contains("20"));//size
        }
    }
}
