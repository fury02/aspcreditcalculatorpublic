using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Web;

using AnnuityCalculatorASPNETCORE3.Models;
using AnnuityCalculatorASPNETCORE3.Helpers;
using AnnuityCalculatorASPNETCORE3.Infrastructure;

using ClassLibraryCreditCalculate;
using LightInject;
using ContainerDI;

namespace AnnuityCalculatorASPNETCORE3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         
        private readonly ServiceContainer _serviceContainer = null;
        private ICreditInfo _creditInfo = null;
        private AllPayments _payinfo = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _serviceContainer = new Container().GetServiceContainer;
            _payinfo = new AllPayments();
            _creditInfo = _serviceContainer.GetInstance<ICreditInfo>();
        }

        public IActionResult Index(BankCreditData bankCreditData)
        {
            var result = _creditInfo.Calculate(bankCreditData);
            _payinfo = new Converter().PaytablesConverter(result);

            HttpContext.Session.SetJson("Payinfo", _payinfo);

            return View();
        }

        public IActionResult TableWithCalculations()
        {
            var result = HttpContext.Session.GetJson<AllPayments>("Payinfo");

            return View(result);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
