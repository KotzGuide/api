using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NikCore.Services;


namespace NikCore.Attributes
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
