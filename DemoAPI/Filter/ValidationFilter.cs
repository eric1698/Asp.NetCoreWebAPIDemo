using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.ViewModels.ErrorHandle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Filter
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                                .Where(m => m.Value.Errors.Count > 0)
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(s => s.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();
                foreach (var error in errors)
                {
                    foreach (var suberror in error.Value)
                    {
                        ErrorModel errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = suberror
                        };

                        errorResponse.Errors.Add(errorModel);
                    }
                }
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            base.OnResultExecuting(context);
        }
    }
}
