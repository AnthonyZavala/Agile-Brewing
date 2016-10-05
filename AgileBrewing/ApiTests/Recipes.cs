using System;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiTests.Models;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class Recipes
    {
        static HttpClient _client = new HttpClient();

        public Recipes()
        {
            _client.BaseAddress = new Uri("http://localhost:10491/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Test]
        public async Task CRUD()
        {
            var expectedRecipe = new Recipe
            {
                Name = $"Test - {Guid.NewGuid()}",
                StyleId = $"Test - {Guid.NewGuid()}",
                OriginalGravity = 1.040m,
                FinalGravity = 1.007m
            };

            HttpResponseMessage createResponse = await _client.PostAsJsonAsync("odata/Recipes", expectedRecipe);
            Assert.AreEqual(HttpStatusCode.Created, createResponse.StatusCode);
            var createdRecipe = await createResponse.Content.ReadAsAsync<Recipe>();
            AssertRecipe(expectedRecipe, createdRecipe, 4.3m);

            HttpResponseMessage getResponse = await _client.GetAsync($"odata/Recipes({createdRecipe.Id})");
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
            var getRecipe = await getResponse.Content.ReadAsAsync<Recipe>();
            AssertRecipe(expectedRecipe, getRecipe, 4.3m);

            var updatedRecipe = new Recipe
            {
                Id  = createdRecipe.Id,
                Name = $"Test - {Guid.NewGuid()}",
                StyleId = $"Test - {Guid.NewGuid()}",
                OriginalGravity = 1.083m,
                FinalGravity = 1.020m
            };

            HttpResponseMessage putResponse = await _client.PutAsJsonAsync($"odata/Recipes({createdRecipe.Id})", updatedRecipe);
            Assert.AreEqual(HttpStatusCode.NoContent, putResponse.StatusCode);
            getResponse = await _client.GetAsync($"odata/Recipes({createdRecipe.Id})");
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
            getRecipe = await getResponse.Content.ReadAsAsync<Recipe>();
            AssertRecipe(updatedRecipe, getRecipe, 8.9m);
            
            HttpResponseMessage deleteResponse = await _client.DeleteAsync($"odata/Recipes({createdRecipe.Id})");
            Assert.AreEqual(HttpStatusCode.NoContent, deleteResponse.StatusCode);
            getResponse = await _client.GetAsync($"odata/Recipes({createdRecipe.Id})");
            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        private static void AssertRecipe(Recipe expectedRecipe, Recipe actualRecipe, decimal expectedAbv)
        {
            Assert.AreEqual(expectedRecipe.Name, actualRecipe.Name);
            Assert.AreEqual(expectedRecipe.StyleId, actualRecipe.StyleId);
            Assert.AreEqual(expectedRecipe.OriginalGravity, actualRecipe.OriginalGravity);
            Assert.AreEqual(expectedRecipe.FinalGravity, actualRecipe.FinalGravity);
            Assert.AreEqual(expectedAbv, actualRecipe.Abv);
        }
    }
}
