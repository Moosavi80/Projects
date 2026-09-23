namespace PropertyManagementProject.Data
{
    public static class DbConnectionFactory
    {
        private static BussinusLogic.DbFunction? _dbFunction = null;
        private static readonly object _lock = new();

        public static BussinusLogic.DbFunction DbInstance
        {
            get
            {
                if (_dbFunction == null)
                                    throw new InvalidOperationException("DbFunction IS NULL.");
                return _dbFunction;
            }
        }

        public static void Initialize(string connectionString)
        {
            lock (_lock)
            {
                _dbFunction ??= new BussinusLogic.DbFunction(connectionString);
            }
        }
    }
}