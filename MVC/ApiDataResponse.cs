using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenesium.Foundation.CommonMVC
{
    [Serializable]
    public class ApiDataResponse : IApiResponse
    {
        public bool Success { get; set; }
        public bool ReloadApplication { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string RedirectUrl { get; set; }

        public List<ValidationErrorModel> ValidationErrors { get; set; }

        public ApiDataResponse(object data)
        {
            this.Success = true;
            this.Data = data;
            this.RedirectUrl = String.Empty;
        }
    }
}