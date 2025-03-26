using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class BudgetController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
