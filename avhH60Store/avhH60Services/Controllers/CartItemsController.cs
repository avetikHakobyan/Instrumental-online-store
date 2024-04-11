using avhH60Common.DAL;
using avhH60Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace avhH60Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly IStoreRepository _storeDbRepository;

        public CartItemsController(IStoreRepository storeRepository)
        {
            _storeDbRepository = storeRepository;
        }

        // GET: api/CartItems/5
        [HttpGet("{cartItemId}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int cartItemId)
        {
            if (cartItemId == 0)
            {
                return BadRequest();
            }
            try
            {
                return await _storeDbRepository.GetCartItem(cartItemId);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/CartItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("customerId={customerId}&productId={productId}&quantity={quantity}")]
        public async Task<ActionResult<CartItem>> PostCartItem(int customerId, int productId, int quantity)
        {
            try
            {
                await _storeDbRepository.CreateCartItem(customerId, productId, quantity);
                //var cartItem = await _storeDbRepository.GetCartItem(
                //                                        (await _storeDbRepository
                //                                        .GetShoppingCart(customerId))
                //                                        .CartItems
                //                                        .FirstOrDefault(c => c.ProductId == productId).CartItemId);
                //return CreatedAtAction("GetCartItem", new { cartItemId = cartItem.CartItemId }, cartItem);
                return Ok();
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            try
            {
                await _storeDbRepository.DeleteCartItem(cartItemId);
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
