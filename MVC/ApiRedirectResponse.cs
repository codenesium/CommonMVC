using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenesium.Foundation.CommonMVC
{
    [Serializable]
    public class ApiRedirectResponse : IApiResponse
    {
        public bool Success { get; set; }
        public bool ReloadApplication { get; set; }
        public string Message { get; set; }
        public string RedirectUrl { get; set; }
        public object Data { get; set; }
        public List<ValidationErrorModel> ValidationErrors { get; set; }

        public ApiRedirectResponse(string redirectUrl)
        {
            this.Success = true;
            this.RedirectUrl = redirectUrl;
        }

        public ApiRedirectResponse()
        {
            this.Success = true;
            this.Message = String.Empty;
            this.RedirectUrl = String.Empty;
        }
    }
}