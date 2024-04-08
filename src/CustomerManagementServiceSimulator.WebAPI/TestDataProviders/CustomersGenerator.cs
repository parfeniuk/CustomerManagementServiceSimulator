using CustomerManagementServiceSimulator.WebAPI.Models;

namespace CustomerManagementServiceSimulator.WebAPI.TestDataProviders
{
    public static class CustomersGenerator
    {
        public static IEnumerable<CustomerModel> GenerateCustomers(int count, int minAge, int maxAge)
        {
            var customers = new List<CustomerModel>();

            for (int i = 0; i < count; i++)
            {
                customers.Add(new CustomerModel
                {
                    Id = CustomerSequentialIdProvider.GetNextId(),
                    FirstName = CustomerNamesProvider.GetRandomFirstName(),
                    LastName = CustomerNamesProvider.GetRandomLastName(),
                    Age = CustomerAgeProvider.GetRandomAge(minAge, maxAge),
                });
            };

            return customers;
        }
    }
}
