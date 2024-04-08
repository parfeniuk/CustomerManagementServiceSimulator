using CustomerManagementServiceSimulator.WebAPI.Models;

namespace CustomerManagementServiceSimulator.WebAPI.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomerModel>> GetCustomersInParallelAsync();

        Task<IEnumerable<CustomerModel>> GetCustomerByIdInParallelAsync(int id);

        Task<bool> CreateCustomersInParallelAsync(int lastId);
    }
}
