using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WarehouseManagmentWEB.Tools.Api;
using WarehouseManagmentWEB.Tools.Api.Models;

namespace WarehouseManagmentWEB.Pages.Shared
{
    public class OrdersModel : PageModel
    {
        private int typeOfSort { get; set; }
        private int lastClicked { get; set; }
        public List<OrderModel>? OrdersList;
        public OrdersModel()
        {
            typeOfSort = Singleton.Instance.OrderSortType;
            lastClicked = Singleton.Instance.OrderSortTypeLast;

            var orders = Orders.GetOrders();

            if (typeOfSort == 0)
                OrdersList = orders;

            if (typeOfSort == 1)
            {
                if (lastClicked == 1 || lastClicked == 100)
                {
                    OrdersList = orders?.OrderBy(x => x.iD_zamowienia).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderByDescending(x => x.iD_zamowienia).ToList();
                    lastClicked = 1;
                }
            }

            if (typeOfSort == 2)
            {
                if (lastClicked == 2 || lastClicked == 100)
                {
                    OrdersList = orders?.OrderBy(x => x.iD_kartonu).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderByDescending(x => x.iD_kartonu).ToList();
                    lastClicked = 2;
                }
            }

            if (typeOfSort == 3)
            {
                if (lastClicked == 3 || lastClicked == 100)
                {
                    OrdersList = orders?.OrderBy(x => x.iD_kartonu2).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderByDescending(x => x.iD_kartonu2).ToList();
                    lastClicked = 3;
                }
            }

            if (typeOfSort == 4)
            {
                if (lastClicked == 4 || lastClicked == 100)
                {
                    OrdersList = orders?.OrderBy(x => x.czy_na_stanie).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderByDescending(x => x.czy_na_stanie).ToList();
                    lastClicked = 4;
                }
            }

            if (typeOfSort == 5)
            {
                if (lastClicked == 5 || lastClicked == 100)
                {
                    OrdersList = orders?.OrderBy(x => x.pozycje.Min(y=>y.sku)).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderByDescending(x => x.pozycje.Min(y => y.sku)).ToList();
                    lastClicked = 5;
                }
            }

            if (typeOfSort == 6)
            {
                if (lastClicked == 6 || lastClicked == 100)
                {
                    OrdersList = orders?.OrderBy(x => x.pozycje.Sum(y => y.ilosc)).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderByDescending(x => x.pozycje.Sum(y => y.ilosc)).ToList();
                    lastClicked = 6;
                }
            }

            if (typeOfSort == 7)
            {
                if (lastClicked == 7 || lastClicked == 100)
                {
                    OrdersList = orders?.OrderBy(x => x.pozycje.Any(y=>y.czy_na_stanie)).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderByDescending(x => x.pozycje.Any(y => y.czy_na_stanie)).ToList();
                    lastClicked = 7;
                }
            }

            Singleton.Instance.OrderSortTypeLast = lastClicked;
        }
        public void OnGet()
        {
        }
        public void Funct()
        {
        }
    }
}
