namespace WarehouseManagmentWEB.Tools.Api.Models
{
    public class ProductModel
    {
        public string SKU { get; set; }
        public string Nazwa_produktu { get; set; }
        public int ID_kartonu { get; set; }
        public int Stan_magazynowy { get; set; }
        public int Potrzebna_ilosc { get; set; }
    }
}
