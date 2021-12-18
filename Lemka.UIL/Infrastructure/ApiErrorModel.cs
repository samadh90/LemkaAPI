using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lemka.UIL.Infrastructure;

public class ApiErrorModel
{
    public string Message { get; set; }
    public bool IsError { get; set; }
    public string Detail { get; set; }
    public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }

    public ApiErrorModel(string message)
    {
        Message = message;
        IsError = true;
    }

    public ApiErrorModel(ModelStateDictionary modelState)
    {
        IsError = true;
        if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
        {
            Message = "Please correct the specified errors and try again.";
            Errors = modelState.SelectMany(m =>
            {
                return m.Value.Errors.Select(me => new KeyValuePair<string, string>(m.Key, me.ErrorMessage));
            });
            //errors = modelState.SelectMany(m => m.Value.Errors.Select(me => new ModelError { FieldName = m.Key, ErrorMessage = me.ErrorMessage }));
        }
    }
}

