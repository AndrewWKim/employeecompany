using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SomeCompanyEmployees.Initiation;

namespace SomeCompanyEmployees
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Initialize.InitializeUsers();
			Initialize.InitializeProducts();
			Initialize.InitializeOrders();
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
