using server.Data;
using server.Models;

namespace server.Services
{
	public class OrderDetailService
	{
		private readonly ApplicationDbContext _context;

		public OrderDetailService(ApplicationDbContext context)
		{
			_context = context;
		}

		// Create a new order detail
		public OrderDetail CreateOrderDetail(OrderDetail orderDetail)
		{
			if (orderDetail == null)
				throw new ArgumentNullException(nameof(orderDetail));

			_context.OrderDetails.Add(orderDetail);
			_context.SaveChanges();

			return orderDetail;
		}

		// Get an order detail by ID
		public OrderDetail GetOrderDetailById(int orderDetailId)
		{
			return _context.OrderDetails
				.FirstOrDefault(od => od.OrderDetailId == orderDetailId);
		}

		// Get all order details
		public List<OrderDetail> GetAllOrderDetails()
		{
			return _context.OrderDetails.ToList();
		}

		// Update an existing order detail
		public void UpdateOrderDetail(OrderDetail orderDetail)
		{
			if (orderDetail == null)
				throw new ArgumentNullException(nameof(orderDetail));

			var existingOrderDetail = _context.OrderDetails
				.FirstOrDefault(od => od.OrderDetailId == orderDetail.OrderDetailId);

			if (existingOrderDetail == null)
				throw new InvalidOperationException("Order detail not found");

			// Update fields of the existing order detail
			existingOrderDetail.Quantity = orderDetail.Quantity;
			existingOrderDetail.UnitPrice = orderDetail.UnitPrice;
			// ... update other fields as needed

			_context.SaveChanges();
		}

		// Delete an order detail by ID
		public void DeleteOrderDetail(int orderDetailId)
		{
			var orderDetail = _context.OrderDetails
				.FirstOrDefault(od => od.OrderDetailId == orderDetailId);

			if (orderDetail == null)
				throw new InvalidOperationException("Order detail not found");

			_context.OrderDetails.Remove(orderDetail);
			_context.SaveChanges();
		}

	}
}
