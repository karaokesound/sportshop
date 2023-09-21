using Microsoft.AspNetCore.Mvc.Filters;

namespace Sportshop.Application.Validations
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //if (context.ActionArguments.ContainsKey("command"))
            //{
            //    var command = context.ActionArguments["command"];

            //    if (command is RegisterUserCommand registerUserCommand)
            //    {
            //        var validator = new RegisterUserCommandValidator();
            //        var validationResult = await validator.ValidateAsync(registerUserCommand);

            //        if (!validationResult.IsValid)
            //        {
            //            var errorResponse = new ErrorResponse();

            //            foreach (var error in validationResult.Errors)
            //            {
            //                var errorModel = new ErrorModel()
            //                {
            //                    FieldName = error.PropertyName,
            //                    Error = error.ErrorMessage
            //                };

            //                errorResponse.Errors.Add(errorModel);
            //            }

            //            context.Result = new BadRequestObjectResult(errorResponse);
            //            return;
            //        }
            //    }
            //}

            //await next();
        }
    }

}
