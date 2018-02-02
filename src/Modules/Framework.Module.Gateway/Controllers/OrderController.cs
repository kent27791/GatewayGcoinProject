using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Gateway.Controllers
{
    [Route("api/order")]
    public class OrderController : Controller
    {
        public OrderController()
        {

        }

        [Route("create")]
        public IActionResult Create()
        {
            return Json("ok");
        }
    }
}
