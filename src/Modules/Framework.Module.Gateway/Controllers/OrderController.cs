using Framework.Module.Gateway.Services;
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
        private readonly ITransactionService _transactionService;
        public OrderController(ITransactionService transactionService)
        {
            this._transactionService = transactionService;
        }

        [Route("create")]
        public IActionResult Create()
        {
            var result = _transactionService.FindAll();
            return Json("ok");
        }
    }
}
