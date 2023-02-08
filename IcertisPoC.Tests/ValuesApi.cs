using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using Xunit;

namespace IcertisPoC.Tests
{
    public class ValuesApi: IDisposable
    {
        private readonly IWebDriver _driver;
        private HttpClient _client;
        private static string baseUrl = "https://localhost:5001/";


        public ValuesApi()
        {
            _driver = new ChromeDriver();
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
        }


        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void TestGetApi()
        {
            _driver.Navigate().GoToUrl($"{baseUrl}api/values");
            var response = _driver.FindElement(By.TagName("body")).Text;

            Assert.Contains("Hello World!", response);
        }

        [Fact]
        public async void TestPostApi()
        {
            int num1 = 20;
            int num2 = 5;

            var response = await _client.PostAsync($"api/values/divide?num1={num1}&num2={num2}", null);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var responseData = response.Content.ReadAsStringAsync().Result;
            Assert.Equal((num1 / num2), Convert.ToDecimal(responseData));
        }

        [Fact]
        public async void TestPutApi()
        {
            string name = "Nischal";

            var response = await _client.PutAsync($"/api/values/greeting?name={name}", null);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseData = response.Content.ReadAsStringAsync().Result;
            Assert.Equal($"Hello, {name}!", responseData);
        }
    }
}
