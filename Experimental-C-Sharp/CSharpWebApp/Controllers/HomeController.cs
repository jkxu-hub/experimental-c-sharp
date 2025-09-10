using System.Diagnostics;
using System.Security.Claims;
using CSharpWebApp.Hubs;
using CSharpWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CSharpWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<CustomHub> _customHub;
        private readonly ChatRegistry _chatRegistry;

        public HomeController(ILogger<HomeController> logger, IHubContext<CustomHub> customHub, ChatRegistry chatRegistry)
        {
            _logger = logger;
            _customHub = customHub;
            _chatRegistry = chatRegistry;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Groups()
        {
            return View();
        }

        public IActionResult AdvancedChat()
        {
            return View();
        }

        [HttpGet("/send")]
        public async Task<IActionResult> SendData()
        {
            await _customHub.Clients.All.SendAsync("client_function_name", new Data(100, "Dummy Data"));
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /* Beginning of feature involving AdvancedChat */
        [AllowAnonymous]
        [HttpGet("/auth")]
        public IActionResult Authenticate(string username)
        {
            var claims = new Claim[]
            {
                new("user_id", Guid.NewGuid().ToString()),
                new("username", username),
            };

            var identity = new ClaimsIdentity(claims, "Cookie");
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync("Cookie", principal);
            return Ok();
        }

        [HttpGet("/create")]
        public IActionResult CreateRoom(string room)
        {
            _chatRegistry.CreateRoom(room);
            return Ok();
        }

        [HttpGet("/list")]
        public IActionResult ListRooms()
        {
            return Ok(_chatRegistry.GetRooms());
        }


    }
}
