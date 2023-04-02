using Microsoft.AspNetCore.Mvc.RazorPages;
using WarehouseManagmentWEB.Tools.Api;
using WarehouseManagmentWEB.Tools.Api.Models;

namespace WarehouseManagmentWEB.Pages.Shared
{
    public class ProductsModel : PageModel
    {
        private int typeOfSort { get; set; }
        private int lastClicked { get; set; }
        public List<ProductModel>? ProductsList;

        public ProductsModel()
        {
            typeOfSort = Singleton.Instance.ProductSortType;
            lastClicked = Singleton.Instance.ProductSortTypeLast;

            var products = Singleton.Instance.OnlyAvaliableProd? Products.GetAvailableProducts() : Products.GetProducts();
            
            if (typeOfSort == 0)
                ProductsList = products;

            if (typeOfSort == 1)
            {
                if (lastClicked == 1)
                {
                    ProductsList = products?.OrderBy(x => x.SKU).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderByDescending(x => x.SKU).ToList();
                    lastClicked = 1;
                }
            }

            if (typeOfSort == 2)
            {
                if (lastClicked == 2)
                {
                    ProductsList = products?.OrderBy(x => x.Nazwa_produktu).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderByDescending(x => x.Nazwa_produktu).ToList();
                    lastClicked = 2;
                }
            }

            if (typeOfSort == 3)
            {
                if (lastClicked == 3)
                {
                    ProductsList = products?.OrderBy(x => x.Karton.Wysokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderByDescending(x => x.Karton.Wysokosc).ToList();
                    lastClicked = 3;
                }
            }

            if (typeOfSort == 4)
            {
                if (lastClicked == 4)
                {
                    ProductsList = products?.OrderBy(x => x.Karton.Szerokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderByDescending(x => x.Karton.Szerokosc).ToList();
                    lastClicked = 4;
                }
            }

            if (typeOfSort == 5)
            {
                if (lastClicked == 5)
                {
                    ProductsList = products?.OrderBy(x => x.Karton.Glebokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderByDescending(x => x.Karton.Glebokosc).ToList();
                    lastClicked = 5;
                }
            }

            if (typeOfSort == 6)
            {
                if (lastClicked == 6)
                {
                    ProductsList = products?.OrderBy(x => x.Stan_magazynowy).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderByDescending(x => x.Stan_magazynowy).ToList();
                    lastClicked = 6;
                }
            }

            if (typeOfSort == 7)
            {
                if (lastClicked == 7)
                {
                    ProductsList = products?.OrderBy(x => x.Potrzebna_ilosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderByDescending(x => x.Potrzebna_ilosc).ToList();
                    lastClicked = 7;
                }
            }

            Singleton.Instance.ProductSortTypeLast = lastClicked;
        }
        public void OnGet()
        {
        }
    }
}
