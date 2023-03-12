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

            if (typeOfSort == 0)
                ProductsList = Products.GetProducts();

            var products = Products.GetProducts();

            if (typeOfSort == 1)
            {
                if (lastClicked == 1)
                {
                    ProductsList = products?.OrderByDescending(x => x.SKU).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderBy(x => x.SKU).ToList();
                    lastClicked = 1;
                }
            }

            if (typeOfSort == 2)
            {
                if (lastClicked == 2)
                {
                    ProductsList = products?.OrderByDescending(x => x.Nazwa_produktu).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderBy(x => x.Nazwa_produktu).ToList();
                    lastClicked = 2;
                }
            }

            if (typeOfSort == 3)
            {
                if (lastClicked == 3)
                {
                    ProductsList = products?.OrderByDescending(x => x.Karton.Wysokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderBy(x => x.Karton.Wysokosc).ToList();
                    lastClicked = 3;
                }
            }

            if (typeOfSort == 4)
            {
                if (lastClicked == 4)
                {
                    ProductsList = products?.OrderByDescending(x => x.Karton.Szerokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderBy(x => x.Karton.Szerokosc).ToList();
                    lastClicked = 4;
                }
            }

            if (typeOfSort == 5)
            {
                if (lastClicked == 5)
                {
                    ProductsList = products?.OrderByDescending(x => x.Karton.Glebokosc).ToList();
                    lastClicked = 0;
                }
                else
                {
                    ProductsList = products?.OrderBy(x => x.Karton.Glebokosc).ToList();
                    lastClicked = 5;
                }
            }

            Singleton.Instance.ProductSortTypeLast = lastClicked;
        }
        public void OnGet()
        {
        }
    }
}
