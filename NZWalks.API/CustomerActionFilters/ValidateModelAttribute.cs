using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;


namespace NZWalks.API.CustomerActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //base.OnActionExecuted(context);

            if (context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestResult();
            }
        }

    }
}
