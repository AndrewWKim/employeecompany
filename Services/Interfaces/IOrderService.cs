using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeCompanyEmployees.Models;

namespace SomeCompanyEmployees.Services.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<Order>> GetOrdersAsync();
		Task<Order> FindOrderByIdAsync(int id);
		Task AddNewOrderAsync(int clientId, IEnumerable<Product> listProducts);
		Task RemoveOrderAsync(int id);
		Task EditOrderAsync(Order order);
		bool IsOrderExists(int id);
	}
}
