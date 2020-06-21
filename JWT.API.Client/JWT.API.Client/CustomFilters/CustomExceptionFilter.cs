using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace JWT.API.Client.CustomFilters
{

    //public class CustomExceptionFilter : ExceptionFilterAttribute
    //{
    //    public override void OnException(HttpActionExecutedContext actionExecutedContext)
    //    {
    //        string exceptionMessage = string.Empty;
    //        if (actionExecutedContext.Exception.InnerException == null)
    //        {
    //            exceptionMessage = actionExecutedContext.Exception.Message;
    //        }
    //        else
    //        {
    //            exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
    //        }
    //        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
    //        {
    //            Content = new StringContent("An unhandled exception was thrown by service."),
    //            ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
    //        };
    //        actionExecutedContext.Response = response;
    //    }
    //}
    //public class OnExceptionAttribute : ExceptionFilterAttribute
    //{
    //    public override void OnException(HttpActionExecutedContext context)
    //    {
    //        var exceptionType = context.Exception.GetType().ToString();
    //        var exception = context.Exception.InnerException ?? context.Exception;

    //        HttpResponseMessage httpResponseMessage;

    //        switch (exceptionType)
    //        {
    //            case "System.Data.DuplicateNameException":

    //                httpResponseMessage = CreateHttpResponseMessage(context.Request,
    //                    HttpStatusCode.BadRequest, context.Exception.ToString());
    //                break;

    //            case "System.Data.ObjectNotFoundException":
    //            case "System.Data.Entity.Core.ObjectNotFoundException":

    //                httpResponseMessage = CreateHttpResponseMessage(context.Request,
    //                    HttpStatusCode.NotFound, context.Exception.ToString());
    //                break;

    //            case "System.UnauthorizedAccessException":

    //                httpResponseMessage = CreateHttpResponseMessage(context.Request,
    //                    HttpStatusCode.Forbidden, context.Exception.ToString());
    //                break;

    //            case "System.ComponentModel.DataAnnotations.ValidationException":
    //                httpResponseMessage = CreateHttpResponseMessage(context.Request,
    //                    HttpStatusCode.BadRequest, context.Exception.ToString());
    //                break;

    //            case "System.Data.Entity.Infrastructure.DbUpdateException":

    //                httpResponseMessage = CreateHttpResponseMessage(context.Request,
    //                    HttpStatusCode.InternalServerError, "An error occurred, please try again.");
    //                break;

    //            case "System.Data.Entity.Core.OptimisticConcurrencyException":
    //            case "System.Data.OptimisticConcurrencyException":

    //                httpResponseMessage = CreateHttpResponseMessage(context.Request,
    //                    HttpStatusCode.InternalServerError, "An error occurred, please try again. If error persists contact support.");
    //                break;

    //            default:

    //                httpResponseMessage = CreateHttpResponseMessage(context.Request,
    //                            HttpStatusCode.InternalServerError, context.Exception.ToString());
    //                break;
    //        }

    //        context.Response = httpResponseMessage;
    //    }

    //    public HttpResponseMessage CreateHttpResponseMessage(HttpRequestMessage request, HttpStatusCode statusCode, string error)
    //    {
    //        return request.CreateResponse(statusCode, error);
    //    }
    //}
    //public class ProcessException : Exception
    //{
    //    public ProcessException(string message)
    //        : base(message)
    //    { }
    //}
    //public class ProcessExceptionFilterAttribute : ExceptionFilterAttribute
    //{
    //    public override void OnException(HttpActionExecutedContext actionExecutedContext)
    //    {
    //        if (actionExecutedContext.Exception is ProcessException)
    //        {
    //            var res = actionExecutedContext.Exception.Message;
    //            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
    //            {
    //                Content = new StringContent(res),
    //                ReasonPhrase = res
    //            };
    //            actionExecutedContext.Response = response;
    //        }
    //    }
    //}
}