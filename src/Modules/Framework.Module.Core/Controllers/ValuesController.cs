using Framework.Infrastructure.Core.Configuration;
using Framework.Module.Core.Services;
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
        private readonly IRoleService _roleService;
        public ValuesController(ISettings settings, IRoleService roleService)
        {
            this._settings = settings;
            this._roleService = roleService;
        }

        /// <summary>
        /// Get config
        /// </summary>
        /// <returns></returns>
        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            var redis = _settings.Redis;
            return Json(redis);
        }
    }
}
