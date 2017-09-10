using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
