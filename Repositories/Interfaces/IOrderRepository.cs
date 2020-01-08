using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order = SomeCompanyEmployees.Models.Order;

namespace SomeCompanyEmployees.Repositories.Interfaces
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetOrdersAsync();
		Task<Order> FindOrderByIdAsync(int id);
		Task AddNewOrderAsync(Order order);
		Task RemoveOrderAsync(int id);
		Task EditOrderAsync(Order order);
		bool IsOrderExists(int id);
	}
}
