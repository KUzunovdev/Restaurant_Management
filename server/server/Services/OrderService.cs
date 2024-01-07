/*using server.Data;
using server.Models;

namespace server.Services
{
	public class OrderService
	{
		private readonly ApplicationDbContext _context;

		public OrderService(ApplicationDbContext context)
		{
			_context = context;
		}

		// Create a new order with order details
		public Order CreateOrder(Order order)
		{
			if (order == null)
				throw new ArgumentNullException(nameof(order));

			//calculate the total price here, based on order details
			order.TotalPrice = order.OrderDetails.Sum(od => od.Quantity * od.UnitPrice);

			_context.Orders.Add(order);
			_context.SaveChanges();

			return order;
		}

		// Get an order by ID
		public Order GetOrderById(int orderId)
		{
			return _context.Orders
				.FirstOrDefault(o => o.OrderId == orderId);
		}

		// Get all orders
		public List<Order> GetAllOrders()
		{
			return _context.Orders.ToList();
		}

		// Update an existing order
		public void UpdateOrder(Order order)
		{
			if (order == null)
				throw new ArgumentNullException(nameof(order));

			var existingOrder = _context.Orders
				.FirstOrDefault(o => o.OrderId == order.OrderId);

			if (existingOrder == null)
				throw new InvalidOperationException("Order not found");

			// Update fields of the existing order
			existingOrder.TotalPrice = order.TotalPrice; // Recalculate if order details changed
			// ... update other fields as needed

			_context.SaveChanges();
		}

		// Delete an order by ID
		public void DeleteOrder(int orderId)
		{
			var order = _context.Orders
				.FirstOrDefault(o => o.OrderId == orderId);

			if (order == null)
				throw new InvalidOperationException("Order not found");

			_context.Orders.Remove(order);
			_context.SaveChanges();
		}
	}
}
*/