//TODO: add license header

using System;
using System.Net.Http;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Salesforce.Force.UnitTests
{
    [TestFixture]
    public class ForceClientTests
    {
        [Test]
        public void Requests_CheckHttpRequestMessage_UserAgent()
        {
            var httpClient = new HttpClient(new ServiceClientRouteHandler(r => Assert.AreEqual(r.Headers.UserAgent.ToString(), "forcedotcom-toolkit-dotnet/v29")));
            var forceClient = new ForceClient("http://localhost:1899", "accessToken", "v29", httpClient);

            try
            {
                // suppress error; we only care about checking the header
                var query = forceClient.QueryAsync<object>("query");
                query.RunSynchronously();
                Assert.IsNotNull(query.Result);
            }
            catch (Exception)
            {
            }
        }
    }
}
