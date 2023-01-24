using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WarehouseManagmentWEB.PostModels;
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
            if (form == null || form.Login == null || form.Password == null || form.Login == "" || form.Password == "")
                return View(new IndexModel("Uzupełnij wszystkie pola w formularzu."));

            //Pobieranie tokena z API
            string token = Authentication.GetToken(form);

            //Sprawdzenie odpowiedzi z API
            if (token == string.Empty)
                return View(new IndexModel("Error strony skontaktuj się z administratorem."));

            if (token == "Unauthorized")
                return View(new IndexModel("Błędny login lub hasło."));

            Singleton.Instance.Token = token;
            return RedirectToPage("/Shared/MainPage");
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
