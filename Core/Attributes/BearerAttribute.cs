using Api.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core.Attributes
{
    public class BearerAttribute : ActionFilterAttribute
    {
        public TokenService TokenService;
        public BearerAttribute(TokenService tokenService)
        {
            TokenService = tokenService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            TokenService.ValidateToken();

            if (TokenService.IsBearerValid)
                base.OnActionExecuting(context);
            else
                context.Result = new UnauthorizedResult();
        }
    }
}
