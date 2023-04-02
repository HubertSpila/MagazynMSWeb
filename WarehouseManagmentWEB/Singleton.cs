namespace WarehouseManagmentWEB
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();
        public string Token;

        //Sortowanie
        public int CartonSortType;
        public int CartonSortTypeLast;
        public bool CartonSortDesc;

        public int ProductSortType;
        public int ProductSortTypeLast;
        public bool ProductSortDesc;

        public bool OnlyAvaliableProd;

        public int OrderSortType;
        public int OrderSortTypeLast;
        public bool OrderSortDesc;
        Singleton()
        {
            Token = "token";
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                        instance.OnlyAvaliableProd = false;
                        instance.CartonSortDesc = false;
                        instance.ProductSortDesc = false;
                        instance.OrderSortDesc = false;
                    }
                    return instance;
                }
            }
        }
        //Wycięcie cudzysłowia
        public static string TokenWithout()
        {
            string token = Instance.Token.Remove(0, 1);
            token = token.Remove(token.Length - 1, 1);
            
            return token;
        }
    }
}