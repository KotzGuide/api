using Newtonsoft.Json;
using System.Collections.Generic;

namespace NikCore.Models   
{
    public class ResponseError
    {
        public ResponseError(string userError, string developerError, List<PropertyField> invalidProperies = null)
        {
            ErrorForUser = userError;
            ErrorForDeveloper = developerError;
            InvalidProperties = invalidProperies;
        }
        public string ErrorForUser { get; private set; }
        public string ErrorForDeveloper { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<PropertyField> InvalidProperties { get; private set; }
    }
}
