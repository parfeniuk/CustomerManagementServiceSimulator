using CustomerManagementServiceSimulator.WebAPI.Clients;
using CustomerManagementServiceSimulator.WebAPI.Configuration;
using CustomerManagementServiceSimulator.WebAPI.Models;
using CustomerManagementServiceSimulator.WebAPI.TestDataProviders;
using Microsoft.Extensions.Options;

namespace CustomerManagementServiceSimulator.WebAPI.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersClient _customersClient;
        private readonly IOptions<SimulatorSettingsOptions> _simulatorSettingsOptions;
        private readonly IOptions<CustomerCreationSettingsOptions> _customerCreationSettingsOptions;

        public CustomersService(
            ICustomersClient customersClient,
            IOptions<SimulatorSettingsOptions> simulatorSettingsOptions,
            IOptions<CustomerCreationSettingsOptions> customerCreationSettingsOptions)
        {
            _customersClient = customersClient;
            _simulatorSettingsOptions = simulatorSettingsOptions;
            _customerCreationSettingsOptions = customerCreationSettingsOptions;
        }

        public async Task<bool> CreateCustomersInParallelAsync(int lastId)
        {
            var tasks = new List<Task<bool>>();

            var delayBetweenParallelTasks = _simulatorSettingsOptions.Value.DelayBetweenParallelTasksInMilliseconds;

            var delayBetweenIterations = _simulatorSettingsOptions.Value.DelayBetweenIterationsInMilliseconds;

            var minCustomerNumberPerRequest = _customerCreationSettingsOptions.Value.MinCustomerNumberPerRequest;

            var maxCustomerNumberPerRequest = _customerCreationSettingsOptions.Value.MaxCustomerNumberPerRequest;

            var minAge = _customerCreationSettingsOptions.Value.MinAge;

            var maxAge = _customerCreationSettingsOptions.Value.MaxAge;

            CustomerSequentialIdProvider.SetCurrentId(lastId);

            for (var i = 0; i < _simulatorSettingsOptions.Value.IterationsNumber; i++)
            {
                for (var j = 0; j < _simulatorSettingsOptions.Value.ParallelTasksNumber; j++)
                {
                    var customers = CustomersGenerator.GenerateCustomers(
                        Random.Shared.Next(minCustomerNumberPerRequest, maxCustomerNumberPerRequest),
                        minAge,
                        maxAge);

                    tasks.Add(_customersClient.CreateCustomersAsync(customers));

                    if (delayBetweenParallelTasks > 0)
                    {
                        await Task.Delay(delayBetweenParallelTasks);
                    }
                }

                if (delayBetweenIterations > 0)
                {
                    await Task.Delay(delayBetweenIterations);
                }
            }

            await Task.WhenAll(tasks);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerByIdInParallelAsync(int id)
        {
            var tasks = new List<Task<CustomerModel>>();

            var delayBetweenParallelTasks = _simulatorSettingsOptions.Value.DelayBetweenParallelTasksInMilliseconds;

            var delayBetweenIterations = _simulatorSettingsOptions.Value.DelayBetweenIterationsInMilliseconds;

            for (var i = 0; i < _simulatorSettingsOptions.Value.IterationsNumber; i++)
            {
                for (var j = 0; j < _simulatorSettingsOptions.Value.ParallelTasksNumber; j++)
                {
                    tasks.Add(_customersClient.GetCustomerByIdAsync(id));

                    if (delayBetweenParallelTasks > 0) 
                    {
                        await Task.Delay(delayBetweenParallelTasks);
                    }
                }

                if (delayBetweenIterations > 0)
                {
                    await Task.Delay(delayBetweenIterations);
                }
            }

            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomersInParallelAsync()
        {
            var tasks = new List<Task<IEnumerable<CustomerModel>>>();

            var delayBetweenParallelTasks = _simulatorSettingsOptions.Value.DelayBetweenParallelTasksInMilliseconds;

            var delayBetweenIterations = _simulatorSettingsOptions.Value.DelayBetweenIterationsInMilliseconds;

            for (var i = 0; i < _simulatorSettingsOptions.Value.IterationsNumber; i++)
            {
                for (var j = 0; j < _simulatorSettingsOptions.Value.ParallelTasksNumber; j++)
                {
                    tasks.Add(_customersClient.GetCustomersAsync());

                    if (delayBetweenParallelTasks > 0)
                    {
                        await Task.Delay(delayBetweenParallelTasks);
                    }
                }

                if (delayBetweenIterations > 0)
                {
                    await Task.Delay(delayBetweenIterations);
                }
            }

            return (await Task.WhenAll(tasks)).SelectMany(c => c);
        }
    }
}
