using Microsoft.AspNetCore.Mvc;
using SurveyApp.Service.Interfaces;
using SurveyApp.UI.Models;
using System.Diagnostics;

namespace SurveyApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuestionService _questionService;

        public HomeController(ILogger<HomeController> logger, IQuestionService questionService)
        {
            _logger = logger;
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}