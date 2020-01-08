using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeCompanyEmployees.Models;
using SomeCompanyEmployees.Repositories.Interfaces;
using SomeCompanyEmployees.Services.Interfaces;

namespace SomeCompanyEmployees.Services
{
	public class OrderService: IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<IEnumerable<Order>> GetOrdersAsync()
		{
			var result = await _orderRepository.GetOrdersAsync();

			if (result == null)
			{
				return null;
			}
			return result;
		}

		public async Task<Order> FindOrderByIdAsync(int id)
		{
			if (!IsOrderExists(id))
			{
				return null;
			}
			return await _orderRepository.FindOrderByIdAsync(id);
		}

		public async Task AddNewOrderAsync(int clientId, IEnumerable<Product> listProducts)
		{
			var newOrder = new Order(clientId);
			foreach (var prod in listProducts)
			{
				newOrder.AddProduct(prod);
			}
			await _orderRepository.AddNewOrderAsync(newOrder);
		}

		public async Task RemoveOrderAsync(int id)
		{
			await _orderRepository.RemoveOrderAsync(id);
		}

		public async Task EditOrderAsync(Order order)
		{
			await _orderRepository.EditOrderAsync(order);
		}

		public bool IsOrderExists(int id)
		{
			return _orderRepository.IsOrderExists(id);
		}
	}
}
