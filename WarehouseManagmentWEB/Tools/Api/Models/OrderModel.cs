namespace WarehouseManagmentWEB.Tools.Api.Models
{
    public class OrderModel
    {
        public int iD_zamowienia { get; set; }
        public int iD_kartonu { get; set; }
        public bool czy_na_stanie { get; set; }
        public List<ItemModel> pozycje { get; set; }
    }
}
