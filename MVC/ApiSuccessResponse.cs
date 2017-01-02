using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenesium.Foundation.CommonMVC
{
    [Serializable]
    public class ApiSuccessResponse : IApiResponse
    {
        public bool Success { get; set; }
        public bool ReloadApplication { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string RedirectUrl { get; set; }
        public List<ValidationErrorModel> ValidationErrors { get; set; }

        public ApiSuccessResponse(string message)
        {
            this.Success = true;
            this.Message = message;
            this.RedirectUrl = String.Empty;
        }

        public ApiSuccessResponse()
        {
            this.Success = true;
            this.Message = String.Empty;
            this.RedirectUrl = String.Empty;
        }
    }
}