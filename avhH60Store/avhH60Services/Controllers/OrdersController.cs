using avhH60Common.DAL;
using avhH60Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace avhH60Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IStoreRepository _storeDbRepository;
        public OrdersController(IStoreRepository storeDbRepository)
        {
            _storeDbRepository = storeDbRepository;
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(int orderId)
        {
            return Ok(await _storeDbRepository.GetOrder(orderId));
        }

        // GET: api/Orders/2023-03-14 00:00:00.0000000
        [HttpGet("/date/{date}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByDateFulfilled(DateTime date)
        {
            try
            {
                return Ok(await _storeDbRepository.GetOrdersByDateFulfilled(date));
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Orders//customer/1
        [HttpGet("/customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomer(int customerId)
        {
            try
            {
                return Ok(await _storeDbRepository.GetOrdersByCustomer(customerId));
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult> PostOrder(Order order)
        {
            try
            {
                await _storeDbRepository.CreateOrder(order);
                return CreatedAtAction("GetOrder", new {orderId = order.OrderId}, order);
            } catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Orders/1/complete
        [HttpPut("{orderId}/complete")]
        public async Task<ActionResult> CompleteOrder(int orderId)
        {
            try
            {
                await _storeDbRepository.CompleteOrder(orderId);
                return Ok();
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
