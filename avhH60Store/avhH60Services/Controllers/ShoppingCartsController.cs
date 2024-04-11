using avhH60Common.DAL;
using avhH60Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace avhH60Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IStoreRepository _storeDbRepository;
        public ShoppingCartsController(IStoreRepository storeDbRepository)
        {
            _storeDbRepository = storeDbRepository;
        }

        // GET: api/ShoppingCarts/5
        [HttpGet("{customerId}")]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCart(int customerId)
        {
            if (customerId == 0)
            {
                return BadRequest();
            }
            try
            {
                return await _storeDbRepository.GetShoppingCart(customerId);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/ShoppingCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{customerId}")]
        public async Task<ActionResult<ShoppingCart>> PostShoppingCart(int customerId)
        {
            try
            {
                await _storeDbRepository.CreateShoppingCart(customerId);
                return Ok();
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/ShoppingCarts/5
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteShoppingCart(int customerId)
        {
            try
            {
                await _storeDbRepository.DeleteShoppingCart(customerId);
                return NoContent();
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
