using System.Diagnostics;
using CSharpWebApp.Hubs;
using CSharpWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CSharpWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<CustomHub> _customHub;

        public HomeController(ILogger<HomeController> logger, IHubContext<CustomHub> customHub)
        {
            _logger = logger;
            _customHub = customHub;
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
    }
}
