namespace WarehouseManagmentWEB.Tools.Api.Models
{
    public class ItemModel
    {
        public string sku { get; set; }
        public int ilosc { get; set; }
        public int iD_zamowienia { get; set; }
        public bool czy_na_stanie { get; set; }
    }
}