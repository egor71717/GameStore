using System;

namespace GameStore.EntityFramework
{
    public static class ContextSingleton
    {
        private static ApplicationDbContext _instance = null;
        public static String connectionStringName = "DefaultConnection";

        public static ApplicationDbContext GetInstance()
        {
            if (_instance == null)
                _instance = new ApplicationDbContext(connectionStringName);
            return _instance;
        }
    }
}
