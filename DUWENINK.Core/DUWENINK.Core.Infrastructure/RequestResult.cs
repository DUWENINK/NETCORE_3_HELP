using System;
using System.Collections.Generic;
using System.Text;

namespace DUWENINK.Core.Infrastructure
{
    public class GetRequestResult
    {
        public string Url { get; set; }
        //public string JsonDataStr { get; set; }
    }



    public class GetRequestResult<T> : GetRequestResult
    {
        
        public GetRequestResult()
        {

        }
        public T Data { get; set; }
    }
}
