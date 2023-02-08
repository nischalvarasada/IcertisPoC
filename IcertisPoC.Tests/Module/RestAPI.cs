using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;


namespace IcertisPoC.Tests.Module
{
    class RestAPI
    {

        private readonly RestClient _client;

        public RestAPI()
        {
            _client = new RestClient("https://localhost:5001/");
        }

        public RestResponse Divide(int num1, int num2)
        {
            var request = new RestRequest("api/values/divide", Method.Post);
            request.AddParameter("num1", num1);
            request.AddParameter("num2", num2);

            var response = _client.Execute(request);
            return response;
        }

        public RestResponse GetValues()
        {
            var request = new RestRequest("api/values", Method.Get);

            var response = _client.Execute(request);
            return response;
        }

        public RestResponse UpdateGreeting(string name)
        {
            var request = new RestRequest("api/values/greeting", Method.Put);
            request.AddParameter("name", name);

            var response = _client.Execute(request);
            return response;
        }
    }
    // static void Main(string[] args)
    //{
    //    var restApiHelper = new RestAPI();

    //    var divideResponse = restApiHelper.Divide(20, 0);

    //    var getValuesResponse = restApiHelper.GetValues();

    //    var updateGreetingResponse = restApiHelper.UpdateGreeting("Nischal");
    //}
}
//private readonly RestClient _client;

//public RestAPI(string baseUrl)
//{
//    _client = new RestClient(baseUrl);
//}

//public RestResponse GetValue(string resource, int id)
//{
//    var request = new RestRequest("api/values", Method.Get);
//    request.AddUrlSegment("id", id.ToString());

//    return _client.Execute(request);
//}

//static void Main(string[] args)
//{
//    var client = new RestClient("https://localhost:5001/");
//    var request = new RestRequest("api/values", Method.Get);
//    var response = client.Execute(request);

//    Console.WriteLine(response.Content);
//}


//Post: https://localhost:5001/api/values/divide?num1=20&num2=0
//Get: https://localhost:5001/api/values
//Put: https://localhost:5001/api/values/greeting?name=Nischal