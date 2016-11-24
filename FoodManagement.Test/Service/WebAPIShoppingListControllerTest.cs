using FoodManagement.Core.DTO;
using FoodManagement.Service.WebAPI;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Test.Service
{
    [TestClass]
    public class WebAPIShoppingListControllerTest
    {
        private static IDisposable _webApp;
        private static string baseUrl = "http://localhost:9443/";
        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            _webApp = WebApp.Start<Startup>(baseUrl);
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            _webApp.Dispose();
        }
        [TestMethod]
        public async Task GetShoppingListItem()
        {
            using (var httpClient = new HttpClient())
            {
                var getResponse = await httpClient.GetAsync(baseUrl + "api/shoppinglists/65A5FFF3-CD22-4212-8BCF-C8112E3D2B7A/items");
                Assert.IsTrue(getResponse.IsSuccessStatusCode);
            }
        }
        [TestMethod]
        public async Task PostAndDeleteShoppingListItem()
        {
            using (var httpClient = new HttpClient())
            {
                var requestUri = new Uri(baseUrl + "api/shoppinglists/65A5FFF3-CD22-4212-8BCF-C8112E3D2B7A/items");
                var shopItem = new ShoppingListItem() { Name = "Test123", Description = "test", Amount = 3, Store = "Delhaize" };
                StringContent content = new StringContent(JsonConvert.SerializeObject(shopItem), Encoding.UTF8, "application/json");
                var postResponse = await httpClient.PostAsync(requestUri, content);
                Assert.IsTrue(postResponse.IsSuccessStatusCode);
                var location = postResponse.Headers.First(h => h.Key == "Location");
                var getResponse = await httpClient.GetAsync(baseUrl + location.Value.First());
                Assert.IsTrue(getResponse.IsSuccessStatusCode);
                var returnShopItem = JsonConvert.DeserializeObject<ShoppingListItem>(getResponse.Content.ReadAsStringAsync().Result);
                Assert.AreEqual(shopItem.Name, returnShopItem.Name);
                var deleteResponse = await httpClient.DeleteAsync(baseUrl + location.Value.First());
                Assert.IsTrue(deleteResponse.IsSuccessStatusCode);
                var getResponseAfterDelete = await httpClient.GetAsync(baseUrl + location.Value.First());
                Assert.IsFalse(getResponseAfterDelete.IsSuccessStatusCode);
            }
        }
    }
}
