using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp.Web.ViewModels;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}