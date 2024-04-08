using CustomerManagementServiceSimulator.WebAPI.Models;
using CustomerManagementServiceSimulator.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace CustomerManagementServiceSimulator.WebAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersSimulatorController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersSimulatorController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var customers = await _customersService.GetCustomersInParallelAsync();

            if (customers == null || !customers.Any())
            {
                return NotFound();
            }

            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<CustomerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetCustomerByIdInParallelAsync(int id)
        {
            var customers = await _customersService.GetCustomerByIdInParallelAsync(id);

            if (customers == null || !customers.Any())
            {
                return NotFound();
            }

            return Ok(customers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CreateCustomersAsync(CustomerCreateModel customerCreateModel)
        {
            _ = await _customersService.CreateCustomersInParallelAsync(customerCreateModel.LastId);

            return Ok();
        }
    }
}
