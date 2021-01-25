using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace NikCore
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ObjectResult SuccessList(IEnumerable data)
        {
            int Quantity = 0;

            if (data is IEnumerable listedItems)
                Quantity = listedItems.Cast<object>().Count();
            return new OkObjectResult(new 
            { 
                Success = true,
                Quantity,
                Data = data
            });
        }

        protected ObjectResult SuccessId<N>(N id)
        {
            return new OkObjectResult(new
            {
                Success = true,
                Id = id
            });
        }

        protected ObjectResult SuccessData(object data)
        {
            return new OkObjectResult(new 
            {
                Success = true,
                Data = data
            });
        }
    }
}
