using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Model
{
    public class RestRespone
    {
        private int StatusCode;
        private string ResponseData;

        public RestRespone(int StatusCode, string ResponseData)
        {
            this.StatusCode = StatusCode;
            this.ResponseData = ResponseData;
        }

        public int statusCode
        {
            get
            {
                return StatusCode;
            }
        }

        public string ResponseContent
        {
            get
            {
                return ResponseData;
            }
        }

        public override string ToString()
        {
            return String.Format("StatsCode : {0} ResponseData : {1}", statusCode, ResponseData);
        }
    }
}
