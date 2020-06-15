using JWT.API.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace JWT.API.CustomFilters
{
    public class CustomAuthenticationFilter : AuthorizeAttribute, IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            string[] TokenUserName = null;

            if (authorization == null)
            {
                context.ErrorResult = new AuthFailureResult("Missing Authorization Header", request);
                return;
            }
            if (authorization == null && authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthFailureResult("Invalid Authorization Scheme", request);
                return;
            }
            
            TokenUserName = authorization.Parameter.Split(':');
            string Token = TokenUserName[0];
            string UserName = TokenUserName[1];

            if (String.IsNullOrEmpty(Token))
            {
                context.ErrorResult = new AuthFailureResult("Missing Token", request);
                return;
            }

            string vuser = TokenManager.ValidateToken(Token);

            if (UserName != TokenManager.ValidateToken(Token))
            {
                context.ErrorResult = new AuthFailureResult("token not Matched with current User", request);
                return;
            }

            context.Principal = TokenManager.GetPrincipal(Token);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(
                             new AuthenticationHeaderValue("Basic", "realm=localhost"));
            }
            context.Result = new ResponseMessageResult(result);

        }
    }
}