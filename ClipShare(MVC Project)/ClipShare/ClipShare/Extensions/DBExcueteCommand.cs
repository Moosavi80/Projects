namespace ClipShare_Youtube_.Extensions
{
    public static class DBExcueteCommand
    {
        private static DataAccess.DBFunction _dbFunction;

        public static DataAccess.DBFunction DbInstance
        {
            get
            {
                if (_dbFunction == null)
                {
                    _dbFunction = new DataAccess.DBFunction();
                }
                return _dbFunction;
            }
        }
    }
}
