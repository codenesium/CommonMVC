using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.Foundation.CommonMVC
{
    public static class HTTPResponseHelper
    {
        public static HttpResponseMessage ToJSONResponse(this object obj)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(obj))
            };

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
    }
}