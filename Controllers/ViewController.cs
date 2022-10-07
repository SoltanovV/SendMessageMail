using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SendMessageEmail.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
