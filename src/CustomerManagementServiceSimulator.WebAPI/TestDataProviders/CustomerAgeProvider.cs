namespace CustomerManagementServiceSimulator.WebAPI.TestDataProviders
{
    public static class CustomerAgeProvider
    {
       public static int GetRandomAge(int minAge, int maxAge)
        {
            return Random.Shared.Next(minAge, maxAge);
        }
    }
}
