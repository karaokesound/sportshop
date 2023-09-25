using Newtonsoft.Json;

namespace Sportshop.Domain.Models
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = null!;

        public ErrorModel(int statusCode, string message)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}