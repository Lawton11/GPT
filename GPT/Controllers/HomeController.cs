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

        public ActionResult ChatGPT(Question question)
        {
            var apiKey = "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";
            var openai = new OpenAIAPI(apiKey);
            var chat = openai.Chat.CreateConversation();
            chat.AppendUserInput(question.message);
            

            //Button gets form text

            //returns text to controller

            //controller sends text to open ai api

            //open ai api returns res



            string message = "Hello from the controller \n Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            
            return Content(question.response);
        }
    }
}