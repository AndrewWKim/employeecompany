using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeCompanyEmployees.Initiation;
using SomeCompanyEmployees.Models;
using SomeCompanyEmployees.Repositories.Interfaces;

namespace SomeCompanyEmployees.Repositories
{
	public class OrderRepository: IOrderRepository
	{
		public async Task<IEnumerable<Order>> GetOrdersAsync()
		{
			return await Task.Run(() => Initialize.CurrentListOfOrders);
		}

		public async Task<Order> FindOrderByIdAsync(int id)
		{
			if (!IsOrderExists(id))
			{
				return null;
			}
			return await Task.Run(() => Initialize.CurrentListOfOrders.First(x => x.Id == id));
		}

		public async Task AddNewOrderAsync(Order order)
		{
			await Task.Run(() => Initialize.CurrentListOfOrders.Add(order));
		}

		public async Task RemoveOrderAsync(int id)
		{
			var orderToDelete = Initialize.CurrentListOfOrders.First(x => x.Id == id);
			await Task.Run(() => Initialize.CurrentListOfOrders.Remove(orderToDelete));
		}

		public async Task EditOrderAsync(Order order)
		{
			await Task.Run(() => Initialize.CurrentListOfOrders[Initialize.CurrentListOfOrders.FindIndex(ind => ind.Id == order.Id)] = order);
		}

		public bool IsOrderExists(int id)
		{
			return Initialize.CurrentListOfOrders.Any(e => e.Id == id);
		}
	}
}
