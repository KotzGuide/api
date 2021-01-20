﻿using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class ErrorContext
    {
        public List<ResponseError> Errors { get; }

        public bool HasError => Errors.Any();

        public ErrorContext()
        {
            Errors = new List<ResponseError>();
        }

        public void AddError(string UserError, string DeveloperError)
        {
            Errors.Add(new ResponseError(UserError, DeveloperError));
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
