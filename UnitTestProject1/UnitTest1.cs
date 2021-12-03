using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HttpClient httpClient = new HttpClient();
            string getUrl = "http://localhost";
            httpClient.Dispose();
        }
    }
}
