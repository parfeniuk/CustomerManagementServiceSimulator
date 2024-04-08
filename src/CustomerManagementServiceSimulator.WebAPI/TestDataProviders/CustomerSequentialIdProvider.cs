namespace CustomerManagementServiceSimulator.WebAPI.TestDataProviders
{
    public static class CustomerSequentialIdProvider
    {
        private static int _lastId = 0;

        public static int GetNextId()
        {
            return Interlocked.Increment(ref _lastId);
        }

        public static void Reset()
        {
            _lastId = 0;
        }

        public static int GetCurrentId()
        {
            return _lastId;
        }

        public static int SetCurrentId(int id)
        {
            return _lastId = id;
        }
    }
}
