using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{

	[Route("api/orders")]
	[ApiController]
	public class OrdersController : Controller
	{
		private readonly OrderService _orderService;

		public OrdersController(OrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		public IActionResult CreateOrder([FromBody] Order order)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var createdOrder = _orderService.CreateOrder(order);
			return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
		}

		[HttpGet("{id}")]
		public ActionResult<Order> GetOrderById(int id)
		{
			var order = _orderService.GetOrderById(id);
			if (order == null)
			{
				return NotFound();
			}
			return order;
		}

		//add methods for update and delete here
	}
}
