namespace WarehouseManagmentWEB.Tools.Api.Models
{
    public class OrderModel
    {
        public int iD_zamowienia { get; set; }
        public int iD_kartonu { get; set; }
        public int? iD_kartonu2 { get; set; }
        public bool czy_na_stanie { get; set; }
        public List<ItemModel> pozycje { get; set; }
        public int? Zweryfikowano { get; set; }

        public string ZwrocKarton1()
        {
            if(iD_kartonu == null) 
                return string.Empty;

            var carton = Cartons.GetCarton(iD_kartonu);
            if (carton == null)
                return string.Empty;

            return $"{carton.Wysokosc}x{carton.Szerokosc}x{carton.Glebokosc}";
        }
        public string ZwrocKarton2()
        {
            if (iD_kartonu2 == null)
                return string.Empty;

            var carton = Cartons.GetCarton((int)iD_kartonu2);
            if (carton == null)
                return string.Empty;

            return $"{carton.Wysokosc}x{carton.Szerokosc}x{carton.Glebokosc}";
        }
    }
}
