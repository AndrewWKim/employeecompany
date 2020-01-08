using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeCompanyEmployees.Models
{
	public class Order
	{
		public int Id { get; set; }
		public double TotalPrice { get; set; }
		
		public List<Product> OrdersProducts { get; set; } = new List<Product>();

		private int _clientId;
		private static int _globalProductId;

		public Order(int clientId)
		{
			Id = Interlocked.Increment(ref _globalProductId);
			_clientId = clientId;
		}

		public void AddProduct(Product newProd)
		{
			OrdersProducts.Add(newProd);
			TotalPrice += newProd.Price;
		}
	}
}
