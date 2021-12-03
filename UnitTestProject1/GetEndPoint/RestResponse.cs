namespace UnitTestProject1.GetEndPoint
{
    internal class RestResponse
    {
        private int statusCode;

        public RestResponse(int statusCode, string result)
        {
            this.statusCode = statusCode;
        }
    }
}