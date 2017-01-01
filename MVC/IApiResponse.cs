using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.Foundation.CommonMVC
{
    public interface IApiResponse
    {
        bool Success { get; set; }
        bool ReloadApplication { get; set; }
        string RedirectUrl { get; set; }
        string Message { get; set; }
        object Data { get; set; }
        List<ValidationErrorModel> ValidationErrors { get; set; }
    }
}