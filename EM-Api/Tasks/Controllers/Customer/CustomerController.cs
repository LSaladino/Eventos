using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using Shared.Modelviews.Customer;

namespace EventApi.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;     

        public CustomerController(ICustomerManager customerManager)   
        {
            _customerManager = customerManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var customer = await _customerManager.GetAllCustomersAsync();

            if (customer.Any())
            {
                return Ok(customer);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var customerFinded = await _customerManager.GetCustomerByIdAsync(id);

            if (customerFinded.Id == 0)
            {
                return NotFound();
            }
            return Ok(customerFinded);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NewCustomer newCustomer)
        {
            var customerAdded = await _customerManager.InsertCustomerAsync(newCustomer);
            if (customerAdded == null) { return NotFound(); }
            return CreatedAtAction(nameof(Get), new { customerAdded.Id }, customerAdded);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CustomerView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateCustomer updateCustomer)
        {
            var customerUpdated = await _customerManager.UpdateCustomerAsync(updateCustomer);
            if (customerUpdated == null)
            {
                return NotFound();
            }
            return Ok(customerUpdated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var eventExcluded = await _customerManager.DeleteCustomerAsync(id);
            if (eventExcluded == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
