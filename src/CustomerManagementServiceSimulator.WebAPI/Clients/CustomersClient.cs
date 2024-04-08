using CustomerManagementServiceSimulator.WebAPI.Models;

namespace CustomerManagementServiceSimulator.WebAPI.Clients
{
    public class CustomersClient : ICustomersClient
    {
        private const string BaseRoute = "api/customers";
        private readonly HttpClient _httpClient;

        public CustomersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync(new Uri(BaseRoute, UriKind.Relative));
            response.EnsureSuccessStatusCode();

            var customers = await response.Content.ReadFromJsonAsync<IEnumerable<CustomerModel>>();
            return customers;
        }

        public async Task<CustomerModel> GetCustomerByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(new Uri($"{BaseRoute}/{id}", UriKind.Relative));
            response.EnsureSuccessStatusCode();

            var customer = await response.Content.ReadFromJsonAsync<CustomerModel>();
            return customer;
        }

        public async Task<bool> CreateCustomersAsync(IEnumerable<CustomerModel> customers)
        {
            var response = await _httpClient.PostAsJsonAsync(new Uri(BaseRoute, UriKind.Relative), customers);
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
