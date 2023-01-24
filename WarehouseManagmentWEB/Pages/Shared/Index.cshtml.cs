using Microsoft.AspNetCore.Mvc.RazorPages;
using WarehouseManagmentWEB.Controllers;

namespace WarehouseManagmentWEB.Pages
{
    public class IndexModel : PageModel
    {
        public string IsAuthorized = "";

        public IndexModel(string isAuthorized = "")
        {
            IsAuthorized = isAuthorized;
        }

        public void OnGet()
        {
        }
    }
}