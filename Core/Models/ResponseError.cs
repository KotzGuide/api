using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Core.Models   
{
    public class ResponseError
    {
        public ResponseError(string userError, string developerError, List<PropertyField> invalidFields = null)
        {
            ErrorForUser = userError;
            ErrorForDeveloper = developerError;
            InvalidFields = invalidFields;
        }
        public string ErrorForUser { get; private set; }
        public string ErrorForDeveloper { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<PropertyField> InvalidFields { get; private set; }
    }
}
