using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VM.MVC.Models;
using VM.Services.Abstraction;

namespace VM.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScenarioService _scenarioService;

        public HomeController(IScenarioService scenarioService)
        {
            _scenarioService = scenarioService;
        }

        public IActionResult Index()
        {
            return View(_scenarioService.ScenariosToDisplay());
        }

    }
}
