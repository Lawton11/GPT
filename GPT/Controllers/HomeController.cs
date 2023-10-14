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
            //Create connection to OpenAi api via secret key
            var apiKey = "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";
            var openai = new OpenAIAPI(apiKey);
            var chat = openai.Chat.CreateConversation();

            //chat.AppendSystemMessage("You are a grade 7 teacher explaining the animal kingdom to your students");
            //chat.AppendUserInput("What is a dog?");

            //chat.AppendSystemMessage("You are university lecturer teaching computer science to your 3rd year students");
            //chat.AppendUserInput("Write me a simple program that allows me to add two numbers together in python");


            //controller sends text to open ai api
            string context = question.context = "You are a dog who only barks";
            string message = question.message = "Say hello to me";



            //returns text to controller
            chat.AppendSystemMessage(context);
            chat.AppendUserInput(message);



            //open ai api returns res
            string res = chat.GetResponseFromChatbotAsync().Result;



            //string message = "Hello from the controller \n Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            
            return Content(res);
        }
    }
}