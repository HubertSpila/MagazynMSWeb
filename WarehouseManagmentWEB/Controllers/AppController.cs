using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WarehouseManagmentWEB.Models;
using WarehouseManagmentWEB.Pages;
using WarehouseManagmentWEB.Tools.Api;

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
            if(form.Login==""||form.Password=="")
                return View(new IndexModel());

            string token = Authentication.GetToken(form);
            if(token == string.Empty)
                return View(new IndexModel());

            Singleton.Instance.Token= token;
            return MainPage();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult MainPage()
        {
            return View();
        }
    }
}
