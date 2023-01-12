using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WarehouseManagmentWEB.Models;
using WarehouseManagmentWEB.Pages;

namespace WarehouseManagmentWEB.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //return View(new IndexModel());
        }

        [HttpPost]
        public IActionResult Index(LoginModel form)
        {
            var t = this.Request;
            return View(new IndexModel());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
