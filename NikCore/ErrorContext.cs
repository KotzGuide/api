using NikCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikCore
{
    public class ErrorContext
    {
        public List<ResponseError> Errors { get; }
        public bool OverrideResult { get; private set; }

        public bool HasError => Errors.Any();

        public ErrorContext()
        {
            Errors = new List<ResponseError>();
            OverrideResult = true;
        }

        public void SetOverrideResponse(bool overrideResult) => OverrideResult = overrideResult;

        public void AddError(string UserError, string DeveloperError)
        {
            Errors.Add(new ResponseError(UserError, DeveloperError));
        }
        
        public void AddError(string UserError, Exception DeveloperError)
        {
            Errors.Add(new ResponseError(UserError, DeveloperError.Message + "\n\n" + DeveloperError.StackTrace));
        }

        public void AddError(string UserDeveloperError)
        {
            Errors.Add(new ResponseError(UserDeveloperError, UserDeveloperError));
        }
        public void AddErrorWithFields(string UserError, string DeveloperError, List<PropertyField> InvalidFields)
        {
            Errors.Add(new ResponseError(UserError, DeveloperError, InvalidFields));
        }
        public void AddErrorWithFields(string UserDeveloperError, List<PropertyField> InvalidFields)
        {
            Errors.Add(new ResponseError(UserDeveloperError, UserDeveloperError, InvalidFields));
        }

        public void ClearErrors()
        {
            Errors.Clear();
        }
    }
}
