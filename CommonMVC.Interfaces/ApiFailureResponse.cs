using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenesium.Foundation.CommonMVC
{
    [Serializable]
    public class ApiFailureResponse : IApiResponse
    {
        public string Message { get; set; }
        public List<ValidationErrorModel> ValidationErrors { get; set; }

        public ApiFailureResponse()
        {
        }

        /// <summary>
        /// This method takes fluent validation errors and converts them
        /// </summary>
        /// <param name="message"></param>
        /// <param name="validationErrors"></param>
        public ApiFailureResponse(string message, IList<ValidationFailure> validationErrors)
        {

        }

        /// <summary>
        /// This method takes field errors we want to make manually
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ValidationErrors"></param>
        public ApiFailureResponse(string message, List<ValidationErrorModel> validationErrors)
        {
            this.Message = message;
            this.ValidationErrors = validationErrors;
        }

        public ApiFailureResponse(string message)
        {
            this.Message = message;
            this.ValidationErrors = new List<ValidationErrorModel>();
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