using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurveyApp.Data.DataBase;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using SurveyApp.Service.Interfaces;
using SurveyApp.UI.Models;

namespace SurveyApp.UI.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ISurveyService _surveyService;
        private readonly IScoreService _scoreService;
        private readonly UserManager<AspNetUser> _userManager;

        public SurveyController(IQuestionService questionService, ISurveyService surveyService, IScoreService scoreService, UserManager<AspNetUser> userManager)
        {
            _questionService = questionService;
            _surveyService = surveyService;
            _scoreService = scoreService;
            _userManager = userManager;
        }

        public async  Task<IActionResult> Index(QuestionModel questions)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null && questions.selectedQuestions.Count > 4)
            {
                TempData["danger"] = "Non-members can add up to 4 questions to the survey.";
                return RedirectToAction("SurveyQuestions");
            }
            if (user != null && questions.selectedQuestions.Count > 10)
            {
                TempData["danger"] = "You can add up to 10 questions to the survey.";
                return RedirectToAction("SurveyQuestions");
            }
            var surveyQuestions = _questionService.GetQuestionList(questions);
            TempData["success"] = "Select the answers.";
            return View(surveyQuestions);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSurvey(SurveyDTO survey)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user!=null)
            {
                survey.AppUserId = user.Id;
            }
            Guid surveyId = _surveyService.Add(survey);
            TempData["success"] = "Survey has been created";
            return RedirectToAction("Survey", new { id = surveyId });
        }

        public IActionResult Survey(Guid id)
        {
            var survey = _surveyService.GetById(id);
            
            return View(survey);
        }
        [HttpPost]
        public IActionResult CreateScore(ScoreDTO score)
        {
            _scoreService.Add(score);
            TempData["success"] = "Survey result recorded";
            return RedirectToAction("ScoreResult" , new { id = score.Id });
        }
        public IActionResult ScoreResult(Guid id)
        {
            var score =_scoreService.GetById(id);
            return View(score);
        }
        public IActionResult SurveyResults(Guid id)
        {
           var scores = _scoreService.GetScoresBySurvey(id);
            return View(scores);
        }
        public IActionResult GetSurveyResults(string surveyLink)
        {
            try
            {
                Uri uri = new Uri(surveyLink);
                string guid = uri.Segments.Last();
                string surveyResultPageUrl = "/Survey/SurveyResults/" + guid;

                return Redirect(surveyResultPageUrl);
            }
            catch (UriFormatException)
            {
                return View("FindSurveyResults");
            }
            
        }
        public IActionResult FindSurveyResults()
        {
            return View();
        }
        public async Task<IActionResult> UserScore()
        {
            var user = await _userManager.GetUserAsync(User);
            var surveyList = _surveyService.GetAllByUserId(user.Id);
            return View(surveyList);
;
        }
        public IActionResult SurveyQuestions()
        {
            var questions = _questionService.GetAllConfirmedQuestion().ToList();
            return View(questions);
        }
    }
}
