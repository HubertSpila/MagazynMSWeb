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

            if (typeOfSort == 0)
                OrdersList = Orders.GetOrders();

            var orders = Orders.GetOrders();

            if (typeOfSort == 1)
            {
                if (lastClicked == 1)
                {
                    OrdersList = orders?.OrderByDescending(x => x.iD_zamowienia).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderBy(x => x.iD_zamowienia).ToList();
                    lastClicked = 1;
                }
            }

            if (typeOfSort == 2)
            {
                if (lastClicked == 2)
                {
                    OrdersList = orders?.OrderByDescending(x => x.iD_kartonu).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderBy(x => x.iD_kartonu).ToList();
                    lastClicked = 2;
                }
            }

            if (typeOfSort == 3)
            {
                if (lastClicked == 3)
                {
                    OrdersList = orders?.OrderByDescending(x => x.iD_kartonu2).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderBy(x => x.iD_kartonu2).ToList();
                    lastClicked = 3;
                }
            }

            if (typeOfSort == 4)
            {
                if (lastClicked == 4)
                {
                    OrdersList = orders?.OrderByDescending(x => x.czy_na_stanie).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderBy(x => x.czy_na_stanie).ToList();
                    lastClicked = 4;
                }
            }

            /*if (typeOfSort == 5)
            {
                if (lastClicked == 5)
                {
                    OrdersList = orders?.OrderByDescending(x => x.sku).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderBy(x => x.Stan_magazynowy).ToList();
                    lastClicked = 5;
                }
            }*/

            /*if (typeOfSort == 6)
            {
                if (lastClicked == 6)
                {
                    OrdersList = orders?.OrderByDescending(x => x.Potrzebna_ilosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderBy(x => x.Potrzebna_ilosc).ToList();
                    lastClicked = 6;
                }
            }

            if (typeOfSort == 7)
            {
                if (lastClicked == 7)
                {
                    OrdersList = orders?.OrderByDescending(x => x.Potrzebna_ilosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    OrdersList = orders?.OrderBy(x => x.Potrzebna_ilosc).ToList();
                    lastClicked = 7;
                }
            }*/

            Singleton.Instance.OrderSortTypeLast = lastClicked;
        }
        public void OnGet()
        {
        }
    }
}
