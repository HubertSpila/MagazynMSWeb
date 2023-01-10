using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using WarehouseManagmentWEB.Tools.Api;

namespace WarehouseManagmentWEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            _configuration["Token"] = Authentication.GetToken();
        }

        public void OnGet()
        {

        }
    }
}