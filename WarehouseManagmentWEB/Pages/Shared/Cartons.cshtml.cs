using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WarehouseManagmentWEB.Tools.Api;
using WarehouseManagmentWEB.Tools.Api.Models;

namespace WarehouseManagmentWEB.Pages.Shared
{
    public class CartonsModel : PageModel
    {
        private int typeOfSort { get; set; }
        private int lastClicked { get; set; }

        public List<CartonModel>? CartonsList;
        
        public CartonsModel()
        {
            typeOfSort = Singleton.Instance.CartonSortType;
            lastClicked = Singleton.Instance.CartonSortTypeLast;

            if (typeOfSort == 0)
                CartonsList = Cartons.GetCartons();

            var cartons = Cartons.GetCartons();

            if (typeOfSort == 1)
            {
                if(lastClicked == 1)
                {
                    CartonsList = cartons?.OrderBy(x => x.ID_kartonu).ToList();
                    lastClicked = 0;
                }
                else
                {
                    CartonsList = cartons?.OrderByDescending(x => x.ID_kartonu).ToList();
                    lastClicked = 1;
                }
            }
                
            if (typeOfSort == 2)
            {
                if (lastClicked == 2)
                {
                    CartonsList = cartons?.OrderBy(x => x.Wysokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    CartonsList = cartons?.OrderByDescending(x => x.Wysokosc).ToList();
                    lastClicked = 2;
                }
            }

            if (typeOfSort == 3)
            {
                if (lastClicked == 3)
                {
                    CartonsList = cartons?.OrderBy(x => x.Szerokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    CartonsList = cartons?.OrderByDescending(x => x.Szerokosc).ToList();
                    lastClicked = 3;
                }
            }

            if (typeOfSort == 4)
            {
                if (lastClicked == 4)
                {
                    CartonsList = cartons?.OrderBy(x => x.Glebokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    CartonsList = cartons?.OrderByDescending(x => x.Glebokosc).ToList();
                    lastClicked = 4;
                }
            }

            if (typeOfSort == 5)
            {
                if (lastClicked == 5)
                {
                    CartonsList = cartons?.OrderBy(x => x.Stan_magazynowy).ToList();
                    lastClicked = 0;
                }
                else
                {
                    CartonsList = cartons?.OrderByDescending(x => x.Stan_magazynowy).ToList();
                    lastClicked = 5;
                }
            }

            if (typeOfSort == 6)
            {
                if (lastClicked == 6)
                {
                    CartonsList = cartons?.OrderBy(x => x.Potrzebna_ilosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    CartonsList = cartons?.OrderByDescending(x => x.Potrzebna_ilosc).ToList();
                    lastClicked = 6;
                }
            }

            Singleton.Instance.CartonSortTypeLast = lastClicked;
        }
        public void OnGet()
        {
        }
    }
}