using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.UI.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
