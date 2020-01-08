using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SomeCompanyEmployees.Entities;
using SomeCompanyEmployees.Repositories;
using SomeCompanyEmployees.Repositories.Interfaces;
using SomeCompanyEmployees.Services;
using SomeCompanyEmployees.Services.Interfaces;
using Stripe;
using OrderService = SomeCompanyEmployees.Services.OrderService;

namespace SomeCompanyEmployees
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.PropertyNamingPolicy = null;
				});

			RegisterServices(services);
			RegisterRepositories(services);

			services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
		}

		private void RegisterServices(IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IOrderService, OrderService>();
		}

		private void RegisterRepositories(IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(options => options.WithOrigins(Configuration.GetConnectionString("localui"))
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
