using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Product.Service.Main;
using Product.Service.Main.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.UnitTests
{
    [TestClass]
    public class ProductTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly string ExistingId = "5225ec77-f735-4f47-80a8-4957298d64f4";
        private readonly string NotExistingId = "5225ec77-f735-4f47-80a8-4957298d64f3";

        public ProductTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .UseStartup<Startup>());
                _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task GetAllTest()
        {
            var response = await _client.GetAsync("/v1/Product/GetAll");
            response.EnsureSuccessStatusCode();

            string responsestring = await response.Content.ReadAsStringAsync();
            var prudctList = JsonConvert.DeserializeObject<List<ProductModel>>(responsestring);

            Assert.IsTrue(prudctList.Any());
        }

        [TestMethod]
        public async Task GetTest_200()
        {
            var response = await _client.GetAsync("/v1/Product/Get/" + ExistingId); //don't have dbcontext
            response.EnsureSuccessStatusCode();

            string responsestring = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductModel>(responsestring);

            Assert.IsNotNull(product);
        }

        [TestMethod]
        public async Task GetTest_404()
        {
            var response = await _client.GetAsync("/v1/Product/Get/" + NotExistingId); //don't have dbcontext

            string responsestring = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductModel>(responsestring);

            Assert.IsNull(product);
        }

        [TestMethod]
        public async Task UpdateDescriptionTest_200()
        {
            string newDescription = "Test new description :)";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(_server.BaseAddress + "v1/Product/UpdateDescription?id=" + ExistingId),
                Content = new StringContent("\""+ newDescription + "\"", Encoding.UTF8, "text/json"),
            };

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string responsestring = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductModel>(responsestring);

            Assert.AreEqual(product.Description, newDescription);
        }

        [TestMethod]
        public async Task UpdateDescriptionTest_404()
        {
            string newDescription = "Test new description :)";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(_server.BaseAddress + "v1/Product/UpdateDescription?id=" + NotExistingId),
                Content = new StringContent("\"" + newDescription + "\"", Encoding.UTF8, "text/json"),
            };

            var response = await _client.SendAsync(request);

            string responsestring = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductModel>(responsestring);

            Assert.IsNull(product);
        }
    }
}
