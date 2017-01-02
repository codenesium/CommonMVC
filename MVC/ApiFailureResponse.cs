using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenesium.Foundation.CommonMVC
{
    [Serializable]
    public class ApiFailureResponse : IApiResponse
    {
        public bool Success { get; set; }
        public bool ReloadApplication { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string RedirectUrl { get; set; }
        public List<ValidationErrorModel> ValidationErrors { get; set; }

        /// <summary>
        /// This method takes fluent validation errors and converts them
        /// </summary>
        /// <param name="message"></param>
        /// <param name="validationErrors"></param>
        public ApiFailureResponse(string message, IList<ValidationFailure> validationErrors)
        {
            this.Success = false;
            this.Message = message;
            this.ValidationErrors = ProcessFluentValidationErrors(validationErrors);
            this.RedirectUrl = String.Empty;
        }

        /// <summary>
        /// This method takes field errors we want to make manually
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ValidationErrors"></param>
        public ApiFailureResponse(string message, List<ValidationErrorModel> validationErrors)
        {
            this.Success = false;
            this.Message = message;
            this.ValidationErrors = validationErrors;
            this.RedirectUrl = String.Empty;
        }

        public ApiFailureResponse(string message)
        {
            this.Success = false;
            this.Message = message;
            this.ValidationErrors = new List<ValidationErrorModel>();
            this.RedirectUrl = String.Empty;
        }

        private List<ValidationErrorModel> ProcessFluentValidationErrors(IList<ValidationFailure> validationErrors)
        {
            List<ValidationErrorModel> response = new List<ValidationErrorModel>();
            foreach (var field in validationErrors)
            {
                response.Add(new ValidationErrorModel(field.PropertyName, field.ErrorMessage));
            }
            return response;
        }
    }
}