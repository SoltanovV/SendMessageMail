using Microsoft.AspNetCore.Mvc;

namespace SendMessageEmail.Controllers
{
    public class ViewController : Controller
    {
        // Метод для вызова представления Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
