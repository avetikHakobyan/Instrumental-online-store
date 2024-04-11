using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using avhH60Common.Models;
using avhH60Common.DAL;

namespace avhH60Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IStoreRepository _storeDbRepository;

        public CustomersController(IStoreRepository storeDbRepository)
        {
            _storeDbRepository = storeDbRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return Ok(await _storeDbRepository.GetCustomers());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                return await _storeDbRepository.GetCustomerById(id);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/Customers/customer@email.com/id
        [HttpGet("{email}/id")]
        public async Task<ActionResult<int>> GetCustomerIdByEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return BadRequest();
            }
            try
            {
                return await _storeDbRepository.GetCustomerIdByEmail(email);
            } catch (NullReferenceException ex)
            {
                return NotFound("Customer was not found");
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            try
            {
                await _storeDbRepository.UpdateCustomer(id, customer);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (customer != null)
            {
                try
                {
                    await _storeDbRepository.CreateCustomer(customer);
                    return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
                } catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            return BadRequest();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                await _storeDbRepository.DeleteCustomer(id);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }
    }
}
