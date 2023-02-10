using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WarehouseManagmentWEB.Pages.Shared
{
    public class ProductsModel : PageModel
    {
        public List<ProductsModel> ProductsList = new List<ProductsModel>();
        
        public void OnGet()
        {
        }
    }
}
