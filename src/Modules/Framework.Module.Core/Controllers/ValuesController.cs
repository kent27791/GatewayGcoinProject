using Framework.Infrastructure.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        private readonly ISettings _settings;
        public ValuesController(ISettings settings)
        {
            this._settings = settings;
        }

        [Route("get")]
        public IActionResult Get()
        {
            var redis = _settings.Redis;
            return Json(redis);
        }
    }
}
