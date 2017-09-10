using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using XY.WebAPI.Security.Core;

namespace XY.Pay.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private static HttpClient _client = new HttpClient();
        public HomeController()
        {
            _client.SetToken();
        }
        public async Task<string> Index()
        {
            // 请求订单接口
            string result = string.Empty;
            HttpResponseMessage response = _client.GetAsync("http://localhost:29988/api/home").Result;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }
    }
}