using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace XY.WebAPI.Security.Core
{
    public class XYAuthenticationMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AuthenticationHeaderValue authenticationHeaderValue = request.Headers.Authorization;
            if (authenticationHeaderValue == null)
            {
                return await SendError("Custom authentication header is missing.", HttpStatusCode.Forbidden);
            }
            if (authenticationHeaderValue.Scheme != "JWT" && authenticationHeaderValue.Parameter != Properties.Settings.Default.Key)
            {
                return await SendError("Custom authentication header is missing.", HttpStatusCode.Forbidden);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> SendError(string error, HttpStatusCode code)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(error);
            response.StatusCode = code;
            return Task<HttpResponseMessage>.Factory.StartNew(() => response);
        }
    }
}
