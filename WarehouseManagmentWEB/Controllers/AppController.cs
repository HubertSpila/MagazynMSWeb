using Microsoft.AspNetCore.Mvc;
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
        }

        [HttpPost]
        public IActionResult Index(LoginModel form)
        {
            if (form == null || form.Username == null || form.Password == null || form.Username == "" || form.Password == "")
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

        public IActionResult OrdersImport()
        {
            Orders.ImportOrders();

            return RedirectToPage("/Shared/Orders");
        }


        [HttpPost]
        public IActionResult WerifyOrder(int Id)
        {
            Orders.WerifyOrder(Id);

            return RedirectToPage("/Shared/Orders");
        }
        [HttpPost]
        public IActionResult WarehouseOut(WarehouseOutModel form)
        {
            if (form.Parametry == null) form.Parametry = string.Empty;

            Orders.WarehouseOut(form);

            return RedirectToPage("/Shared/Orders");
        }

        #region Cartons Managment
        [HttpPost]
        public IActionResult ChangeQuantity(ChangeCartonModel form)
        {
            Cartons.ChangeCarton(form);

            return RedirectToPage("/Shared/Cartons");
        }

        [HttpPost]
        public IActionResult EntryCarton(UpdateCartonOrderModel form)
        {
            Orders.UpdateCarton(form);

            return RedirectToPage("/Shared/Orders");
        }

        [HttpPost]
        public IActionResult AddCarton(AddCartonModel form)
        {
            Cartons.AddCarton(form);

            return RedirectToPage("/Shared/AddCartonPage");
        }

        [HttpPost]
        public IActionResult DeleteCarton(int ID_kartonu)
        {
            Cartons.DeleteCarton(ID_kartonu);

            return RedirectToPage("/Shared/Cartons");
        }
        #endregion

        #region Product Managment
        [HttpPost]
        public IActionResult ChangeQuantityProd(ChangeProductModel form)
        {
            if(form.Parametry == null) form.Parametry = string.Empty;
            Products.ChangeProduct(form);

            return RedirectToPage("/Shared/AddProductPage");
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductModel form)
        {
            Products.AddProduct(form);

            return RedirectToPage("/Shared/AddProductPage");
        }
        #endregion
    }
}
