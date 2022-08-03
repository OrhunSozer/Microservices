using FreeCourse.Web.Exceptions;
using FreeCourse.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FreeCourse.Web.Handler
{
    public class ResourceOwnerPasswordTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIdentityService _identityService;
        private readonly ILogger<ResourceOwnerPasswordTokenHandler> _logger;

        public ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor, IIdentityService identityService, ILogger<ResourceOwnerPasswordTokenHandler> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _identityService = identityService;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Get access token from cookie
            var accessToken = await _httpContextAccessor
                                        .HttpContext
                                        .GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            //Add access token value to headers on request.
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            
            //Send on request.
            var response = await base.SendAsync(request, cancellationToken);

            //İf response is Unauthorized, Refresh token will use
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //Get token from by refresh token from identityservice.
                var tokenResponse = await _identityService.GetAccessTokenByRefreshToken();
                if (tokenResponse != null)
                {
                    //Add access token value to headers on request.
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                        tokenResponse.AccessToken);
                    //REPEAT send on request
                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            //İf response is Unauthorized still, throw my exception
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //throw my exception
                throw new UnAuthorizeException();
            }
            return response;
        }
    }
}
