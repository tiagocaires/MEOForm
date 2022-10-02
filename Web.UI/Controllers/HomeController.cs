using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.UI.Models;
using Web.UI.Utils;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var campaign = HttpClientApi.GetCampaignActive().Result;

            FormViewModel form = new FormViewModel
            {
                CampaignId = campaign.Id,
                CampaignName = campaign.Name,
                CampaignDescription = campaign.Description,
                Person = new PersonViewModel(),
                Answers = new List<AnswerViewModel>(),
            };
            foreach (var question in campaign.Questions)
                form.Answers.Add(new AnswerViewModel
                {
                    QuestionId = question.Id,
                    QuestionDescription = question.Description,
                });

            return View(form);
        }

        [HttpPost]
        public IActionResult PostForm([Bind] FormViewModel form)
        {
            var result = HttpClientApi.PostForm(form).Result;
            return RedirectToAction("Index");
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