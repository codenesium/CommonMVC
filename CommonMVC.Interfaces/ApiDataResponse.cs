using System;
using System.Collections.Generic;

namespace Codenesium.Foundation.CommonMVC
{
    [Serializable]
    public class ApiDataResponse  : IApiResponse
    {
        public object Data { get; set; }

        public ApiDataResponse()
        {
        }

        public ApiDataResponse(object data)
        {
            this.Data = data;
        }
    }
}