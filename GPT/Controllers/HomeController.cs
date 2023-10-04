using GPT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OpenAI_API;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace GPT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //GPT
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //GPT 2
        public ActionResult Index()
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

        public ActionResult GPT( string x)
        {
            var apiKey = "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";
            var openai = new OpenAIAPI(apiKey);
            var chat = openai.Chat.CreateConversation();
            chat.AppendUserInput(x);

            return View();
        }
    }
}