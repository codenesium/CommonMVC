namespace Codenesium.Foundation.CommonMVC
{
    public class ValidationErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }

        public ValidationErrorModel(string fieldName, string error)
        {
            this.FieldName = fieldName;
            this.Message = error;
        }
    }
}