using GPT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using OpenAI_API;
using Microsoft.Extensions.Configuration;

namespace GPT.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
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

        [HttpPost]
        public ActionResult ChatGPT(Question question)
        {
            //chat.AppendSystemMessage("You are a grade 7 teacher explaining the animal kingdom to your students");
            //chat.AppendUserInput("What is a dog?");

            //chat.AppendSystemMessage("You are university lecturer teaching computer science to your 3rd year students");
            //chat.AppendUserInput("Write me a simple program that allows me to add two numbers together in python");
            if (!ModelState.IsValid)
            {
            //Create connection to OpenAi api via secret key
                var apiKey = _configuration["ApiKey"];
                var openai = new OpenAIAPI(apiKey);
                var chat = openai.Chat.CreateConversation();


                //controller sends text to open ai api
                string _message = question.message;

                
                //returns text to controller
                chat.AppendUserInput(_message);

                //open ai api returns res
                string res = chat.GetResponseFromChatbotAsync().Result;

                //string message = "Hello from the controller \n Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";



                //If you can't get JSON to work to dispolay text on View. Then you can  change it to "return Content(res);"
                //return Content(res);
                return new JsonResult(new { response = res });
            }
            return View("Index", question);
        }



        public ActionResult ChatGPTFIleReader(Question question)
        {
            //chat.AppendSystemMessage("You are a grade 7 teacher explaining the animal kingdom to your students");
            //chat.AppendUserInput("What is a dog?");

            //chat.AppendSystemMessage("You are university lecturer teaching computer science to your 3rd year students");
            //chat.AppendUserInput("Write me a simple program that allows me to add two numbers together in python");
            if (!ModelState.IsValid)
            {
                //Create connection to OpenAi api via secret key
                var apiKey = _configuration["ApiKey"];
                var openai = new OpenAIAPI(apiKey);
                var chat = openai.Chat.CreateConversation();


                //Read from file

                //Store file text in variable

                //pass file text variable to chatgpt api

                //returns text to controller
                string _message = question.message; //To be removed
                chat.AppendUserInput(_message);

                //open ai api returns res
                string res = chat.GetResponseFromChatbotAsync().Result;

                //string message = "Hello from the controller \n Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

                return new JsonResult(new { response = res });
            }
            return View("Index", question);
        }

    }


}