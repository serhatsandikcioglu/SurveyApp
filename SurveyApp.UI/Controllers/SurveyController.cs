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

        public SurveyController(IQuestionService questionService, ISurveyService surveyService, IScoreService scoreService)
        {
            _questionService = questionService;
            _surveyService = surveyService;
            _scoreService = scoreService;
        }

        public IActionResult Index()
        {
            var questions = _questionService.GetAllConfirmedQuestion().ToList();
            return View(questions);
        }
        [HttpPost]
        public IActionResult CreateSurvey(SurveyDTO survey)
        {
            _surveyService.Add(survey);
            return RedirectToAction("Survey", new { id = survey.Id });
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

    }
}
