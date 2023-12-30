using Microsoft.AspNetCore.Mvc;
using server.Services;

namespace server.Controllers
{

	[Route("api/orderdetails")]
	[ApiController]
	public class OrderDetailsController : Controller
	{
		private readonly OrderDetailService _orderDetailService;

		public OrderDetailsController(OrderDetailService orderDetailService)
		{
			_orderDetailService = orderDetailService;
		}
	}
}
