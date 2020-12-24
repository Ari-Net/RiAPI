using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
namespace APIArishaEPAM.Tests
{
    [TestClass]
    public class FileDelete
    {
        [TestMethod]
        public void TestDelete()
        {
            var client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer CPPB8UPk0osAAAAAAAAYL3jj0is7XQDTDIpvzO7jl0J0BYqr3bPlemDhBBl1WbkH");
            request.AddParameter("application/json", "{\r\n    \"path\": \"/upl.jpg\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string resp = response.Content.ToString();
            NUnit.Framework.Assert.AreEqual(200, (int)response.StatusCode);//status
            NUnit.Framework.Assert.AreEqual(true, resp.Contains("file"));//tag
            NUnit.Framework.Assert.AreEqual(true, resp.Contains("upl.jpg"));//name
            NUnit.Framework.Assert.AreEqual(true, resp.Contains("id:URSsRWTGmWAAAAAAAAA"));//id
        }
    }
}
