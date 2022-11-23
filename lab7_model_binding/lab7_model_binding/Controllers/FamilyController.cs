using lab7_model_binding.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab7_model_binding.Controllers
{
    public class FamilyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new FamilyModel());
        }
        [HttpPost]
        public IActionResult Index(FamilyModel member)
        {

            return Content($"User {member.ToString()} updated!");
        }
    }
}
