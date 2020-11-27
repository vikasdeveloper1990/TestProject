using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using TacoLoco.Contracts.Responses;

namespace TacoLoco.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before controller
            if (!context.ModelState.IsValid)
            {
                var errorsInModel = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key,
                        x => x.Value.Errors.Select(
                            x => x.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var error in errorsInModel)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModels()
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        errorResponse.Errors.Add(errorModel);
                    }
                }


                context.Result = new BadRequestObjectResult(errorResponse);

                return;
            }
            await next();

        }
    }
}
