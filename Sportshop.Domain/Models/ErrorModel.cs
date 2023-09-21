using Newtonsoft.Json;

namespace Sportshop.Domain.Models
{
    public class ErrorModel
    {
        public string FieldName { get; set; } = null!;

        public string Error { get; set; } = null!;

        public ErrorModel(string fieldName, string error)
        {
            FieldName = fieldName;
            Error = error;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}