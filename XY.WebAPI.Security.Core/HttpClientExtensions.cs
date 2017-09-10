using System.Net.Http;
using System.Net.Http.Headers;

namespace XY.WebAPI.Security.Core
{
    public static class HttpClientExtensions
    {
        private static string key= Properties.Settings.Default.Key;
        public static void SetToken(this HttpClient client) =>
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", key);
    }
}
