using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SomeCompanyEmployees.Models
{
	public class Product
	{
		public int Id { get; set; }
		public double Price { get; set; }
		public string Name { get; set; }

		private static int _globalProductId;

		public Product()
		{
			Id = Interlocked.Increment(ref _globalProductId);
		}
	}
}
