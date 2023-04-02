using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WarehouseManagmentWEB.PostModels;
using WarehouseManagmentWEB.Pages;
using WarehouseManagmentWEB.Tools.Api;
using RestSharp;

namespace WarehouseManagmentWEB.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //logowanie
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
            
            //Zapis tokena
            Singleton.Instance.Token = token;
            return RedirectToPage("/Shared/MainPage");
        }
        [HttpPost]
        public IActionResult ChangeQuantity(ChangeCartonModel form)
        {
            Cartons.ChangeCarton(form);

            return RedirectToPage("/Shared/Cartons");
        }
        [HttpPost]
        public IActionResult ChangeQuantityProd(ChangeProductModel form)
        {
            Products.ChangeProduct(form);

            return RedirectToPage("/Shared/AddProductPage");
        }
        [HttpPost]
        public IActionResult AddCarton(AddCartonModel form)
        {
            Cartons.AddCarton(form);

            return RedirectToPage("/Shared/Cartons");
        }

        [HttpPost]
        public IActionResult DeleteCarton(int ID_kartonu)
        {
            Cartons.DeleteCarton(ID_kartonu);

            return RedirectToPage("/Shared/Cartons");
        }
      
        [HttpPost]
        public IActionResult AddProduct(AddProductModel form)
        {
            Products.AddProduct(form);

            return RedirectToPage("/Shared/products");
        }
        [HttpPost]
        public IActionResult EntryCarton(UpdateCartonOrderModel form)
        {
            Orders.UpdateCarton(form);
            
            return RedirectToPage("/Shared/Orders");
        }

        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult OrdersImport()
        {
            Orders.ImportOrders();

            return RedirectToPage("/Shared/Orders");
        }

    }
}
