namespace WarehouseManagmentWEB
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();
        public string Token;
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
                    }
                    return instance;
                }
            }
        }
        public static string TokenWithout()
        {
            string token = Instance.Token.Remove(0, 1);
            token = token.Remove(token.Length - 1, 1);
            
            return token;
        }
    }
}