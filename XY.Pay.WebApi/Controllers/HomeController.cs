using System.Web.Http;

namespace XY.Pay.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Json(new { success = true });
        }
    }
}
