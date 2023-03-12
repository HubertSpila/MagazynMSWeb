using Microsoft.AspNetCore.Mvc;
using WarehouseManagmentWEB.Pages.Shared;

namespace WarehouseManagmentWEB.Controllers
{
    public class SortController : Controller
    {
        public IActionResult SortCartons1()
        {
            Singleton.Instance.CartonSortType = 1;
            return RedirectToPage("/Shared/Cartons");
        }
        public IActionResult SortCartons2()
        {
            Singleton.Instance.CartonSortType = 2;
            return RedirectToPage("/Shared/Cartons");
        }
        public IActionResult SortCartons3()
        {
            Singleton.Instance.CartonSortType = 3;
            return RedirectToPage("/Shared/Cartons");
        }
        public IActionResult SortCartons4()
        {
            Singleton.Instance.CartonSortType = 4;
            return RedirectToPage("/Shared/Cartons");
        }
        public IActionResult SortCartons5()
        {
            Singleton.Instance.CartonSortType = 5;
            return RedirectToPage("/Shared/Cartons");
        }
        public IActionResult SortCartons6()
        {
            Singleton.Instance.CartonSortType = 6;
            return RedirectToPage("/Shared/Cartons");
        }


        public IActionResult SortProducts1()
        {
            Singleton.Instance.ProductSortType = 1;
            return RedirectToPage("/Shared/Products");
        }
        public IActionResult SortProducts2()
        {
            Singleton.Instance.ProductSortType = 2;
            return RedirectToPage("/Shared/Products");
        }
        public IActionResult SortProducts3()
        {
            Singleton.Instance.ProductSortType = 3;
            return RedirectToPage("/Shared/Products");
        }
        public IActionResult SortProducts4()
        {
            Singleton.Instance.ProductSortType = 4;
            return RedirectToPage("/Shared/Products");
        }
        public IActionResult SortProducts5()
        {
            Singleton.Instance.ProductSortType = 5;
            return RedirectToPage("/Shared/Products");
        }

        public IActionResult SortOrders1()
        {
            Singleton.Instance.OrderSortType = 1;
            return RedirectToPage("/Shared/Orders");
        }
        public IActionResult SortOrders2()
        {
            Singleton.Instance.OrderSortType = 2;
            return RedirectToPage("/Shared/Orders");
        }
        public IActionResult SortOrders3()
        {
            Singleton.Instance.OrderSortType = 3;
            return RedirectToPage("/Shared/Orders");
        }
        public IActionResult SortOrders4()
        {
            Singleton.Instance.OrderSortType = 4;
            return RedirectToPage("/Shared/Orders");
        }
        public IActionResult SortOrders5()
        {
            Singleton.Instance.OrderSortType = 5;
            return RedirectToPage("/Shared/Orders");
        }
        public IActionResult SortOrders6()
        {
            Singleton.Instance.OrderSortType = 6;
            return RedirectToPage("/Shared/Orders");
        }
        public IActionResult SortOrders7()
        {
            Singleton.Instance.OrderSortType = 7;
            return RedirectToPage("/Shared/Orders");
        }
    }
}
