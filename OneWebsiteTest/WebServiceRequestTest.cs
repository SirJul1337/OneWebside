using OneWebside;
using Serilog;

namespace OneWebsiteTest
{
    [TestFixture]
    public class WebServiceRequestTest
    {
        private WebserviceRequest _request;
        [SetUp]
        public void SetUp()
        {
            _request = new WebserviceRequest();
        }

        [TestCase(null)]
        public void IsUriValid_FailCauseNull(string url)
        {
            Assert.Throws<UriFormatException>(() => _request.GetResponseAsync(url).Wait());
        }

        [TestCase("https://jsonplaceholder.typicode.com/todos/1")]
        public async Task IsRequestSucces(string url)
        {
            var result = _request.GetResponseAsync(url);
            Assert.IsTrue(result.IsCompletedSuccessfully);
        }
    }
}
