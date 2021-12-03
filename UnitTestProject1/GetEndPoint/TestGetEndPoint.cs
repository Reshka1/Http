using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnitTestProject1.Model.Json;
using UnitTestProject1.Model.Xml;

namespace UnitTestProject1.GetEndPoint
{
    [TestClass]
    public class TestGetEndPoint
    {
        private string getUrl = "http://local";
        private string securegetUrl = "http://local";

        private object httpResponse;

        public object JsonConvert { get; private set; }
        public object HttpClientHeler { get; private set; }
        public object ResponseDataHelper { get; private set; }

        [TestMethod]
        public void TestGetAllEndPoint()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.GetAsync(getUrl);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointWithUri()
        {
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code =>" + statusCode);
            Console.WriteLine("Status Code =>" + (int)statusCode);

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointWithInvalidUrl()
        {
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(getUrl + "/random");
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code =>" + statusCode);
            Console.WriteLine("Status Code =>" + (int)statusCode);

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();

        }

        [TestMethod]
        public void TestGetAllEndPointWithInJsonFormat()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code =>" + statusCode);
            Console.WriteLine("Status Code =>" + (int)statusCode);

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointWithInXmlFormat()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/xml");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code =>" + statusCode);
            Console.WriteLine("Status Code =>" + (int)statusCode);

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointWithInXmlFormatUsingAcceptHeader()
        {
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Accept.Add(jsonHeader);
            //requestHeaders.Add("Accept", "application/xml");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code =>" + statusCode);
            Console.WriteLine("Status Code =>" + (int)statusCode);

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetEndPointUsingSendAsync()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code =>" + statusCode);
            Console.WriteLine("Status Code =>" + (int)statusCode);

            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestUsingStatement()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");

                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using(HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                       // Console.WriteLine("Status Code =>" + statusCode);
                       // Console.WriteLine("Status Code =>" + (int)statusCode);

                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        // Console.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        Console.WriteLine(restResponse.ToString());
                    }

                }
            }

        }

        [TestMethod]
        public void TestDeserilizationOfJsonResponse()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");

                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        Console.WriteLine(httpResponseMessage.ToString());

                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        // Console.WriteLine("Status Code =>" + statusCode);
                        // Console.WriteLine("Status Code =>" + (int)statusCode);

                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        // Console.WriteLine(data);

                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        //Console.WriteLine(restResponse.ToString());

                        List<JsonRoot> jsonRoot = JsonConvert.DeserializeObject<List<JsonRoot>>(restResponse.ResponseContent);
                        Console.WriteLine(jsonRoot[0].ToString());

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(LaptopDetailss));
                        TextReader textReader = new StringReader(restResponse.ResponseContent);
                        LaptopDetailss xmlData = (LaptopDetailss) xmlSerializer.Deserialize(textReader);
                        Console.WriteLine(xmlData.ToString());
                    }

                }
            }

        }

        [TestMethod]
        public void  TestSecureGetEndPoint()
        {
            Dictionary<string, string> httpHeader = new Dictionary<string, string>();
            httpHeader.Add("Accept", "application/json");
            httpHeader.Add("Authorization", "Basic YWRtaW54dQ==");

            RestResponse restResponse = HttpClientHeler.PerformGetRequest(securegetUrl, httpHeader);
            Assert.AreEqual(200, restResponse.StatusCode);

            List<JsonRoot> jsonData = ResponseDataHelper.DeserializeJsonResponse<List<JsonRoot>>(restResponse.ResponseContent);

            Console.WriteLine(jsonData.ToString());
            
        }
    }
}   
