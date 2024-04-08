using CustomerManagementServiceSimulator.WebAPI.Models;

namespace CustomerManagementServiceSimulator.WebAPI.Clients
{
    public interface ICustomersClient
    {
        Task<IEnumerable<CustomerModel>> GetCustomersAsync();

        Task<CustomerModel> GetCustomerByIdAsync(int id);

        Task<bool> CreateCustomersAsync(IEnumerable<CustomerModel> customers);
    }
}
