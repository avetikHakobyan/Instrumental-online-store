using avhH60Common.DAL;
using avhH60Common.DTO;
using avhH60Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace avhH60Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IStoreRepository _storeDbRepository;

        public ProductCategoriesController(IStoreRepository storeDbRepository)
        {
            _storeDbRepository = storeDbRepository;
        }

        // GET: api/ProductCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetCategories()
        {
            return Ok(await _storeDbRepository.GetCategories());
        }

        // GET: api/ProductCategories/products
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductCategoryDTO>>> GetProductCategories()
        {
            return Ok(await _storeDbRepository.GetProductCategories());
        }

        // GET: api/ProductCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                return await _storeDbRepository.GetCategoryById(id);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/ProductCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.CategoryId)
            {
                return BadRequest();
            }

            try
            {
                await _storeDbRepository.UpdateCategory(id, productCategory);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        // POST: api/ProductCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {
            if (productCategory != null)
            {
                try
                {
                    await _storeDbRepository.CreateCategory(productCategory);
                    return CreatedAtAction("GetProductCategory", new { id = productCategory.CategoryId }, productCategory);
                } catch (Exception ex) { 
                    return StatusCode(500, ex.Message);
                }
            }
            return BadRequest();
        }

        // DELETE: api/ProductCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                await _storeDbRepository.DeleteCategory(id);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
