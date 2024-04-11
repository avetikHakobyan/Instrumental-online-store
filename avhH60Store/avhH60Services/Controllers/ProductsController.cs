using avhH60Common.DAL;
using avhH60Common.Models;
using avhH60Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace avhH60Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IStoreRepository _storeDbRepository;
        private readonly IValidationService _validation;

        public ProductsController(IStoreRepository storeDbRepository, IValidationService validationService)
        {
            _storeDbRepository = storeDbRepository;
            _validation = validationService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _storeDbRepository.GetProducts());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                return await _storeDbRepository.GetProductById(id);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }
            try
            {
                _validation.ValidateDuplicateProduct(await _storeDbRepository.GetProducts(), product);
                await _storeDbRepository.UpdateProduct(id, product);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (product != null)
            {
                try
                {
                    await _storeDbRepository.CreateProduct(product);
                    return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
                } catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            return BadRequest();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _storeDbRepository.DeleteProduct(id);
                return NoContent();
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Products/UpdatePrice/5
        [HttpPut("UpdatePrice/{id}")]
        public async Task<IActionResult> UpdatePrice(string buyPrice, string sellPrice, Product product)
        {
            try
            {
                await _storeDbRepository.UpdatePrice(buyPrice, sellPrice, product);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        // PUT: api/Products/UpdateStock/5
        [HttpPut("UpdateStock/{id}")]
        public async Task<IActionResult> UpdateStock(int amount, Product product)
        {
            try
            {
                await _storeDbRepository.UpdateStock(amount, product);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        // GET: api/Products/categories/5
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> FindProductsForCategory(int id)
        {
            try
            {
                return Ok(await _storeDbRepository.GetProductsForCategory(id));
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("FilterProducts")]

        public async Task<IEnumerable<Product>> FilterProducts(string? search, int id, int sort)
        {
            return await _storeDbRepository.FilterProducts(search, id, sort);
        }

    }
}
