using lab5_data_transfer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab5_data_transfer.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewDataPage()
        {
            ViewBag.data = "ViewBag message";
            ViewData["viewData"] = "This is data transfer from view data";
            TempData["tempMsg"] = "This is temporary message from TempData";
            return View();
        }
    }
}