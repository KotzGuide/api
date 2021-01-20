using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Core.Filters
{
    public class ErrorFilter : ActionFilterAttribute
    {
        private readonly ErrorContext ErrorContext;

        public ErrorFilter(ErrorContext errorContext)
        {
            ErrorContext = errorContext;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (ErrorContext.HasError)
            {
                object data;
                data = ErrorContext.Errors;
                context.Result = Error(data);
                if (ErrorContext.Errors.Any(x => x.ErrorForDeveloper.ToLower().Contains("token")))
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                else
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }

        public ObjectResult Error(object data)
        {
            return new ObjectResult(new
            {
                Success = false,
                ErrorData = data
            });
        }
    }
}
