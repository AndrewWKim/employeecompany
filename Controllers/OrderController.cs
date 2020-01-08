using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SomeCompanyEmployees.Entities;
using SomeCompanyEmployees.Initiation;
using SomeCompanyEmployees.Models;
using SomeCompanyEmployees.Services.Interfaces;
using Stripe;
using Order = SomeCompanyEmployees.Models.Order;
using Product = SomeCompanyEmployees.Models.Product;

namespace SomeCompanyEmployees.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
		{
			var listOfOrders = await _orderService.GetOrdersAsync();
			if (listOfOrders == null)
			{
				return NotFound();
			}

			return Ok(listOfOrders);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserInfo>> GetOrder(int id)
		{
			var currentUser = await _orderService.FindOrderByIdAsync(id);

			if (currentUser == null)
			{
				return NotFound();
			}

			return Ok(currentUser);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrder(int id, Order order)
		{
			if (id != order.Id)
			{
				return BadRequest();
			}

			try
			{
				await _orderService.EditOrderAsync(order);
			}
			catch (ArgumentNullException)
			{
				if (!_orderService.IsOrderExists(id))
				{
					return NotFound();
				}
			}

			return Ok();
		}

		[HttpPost]
		public async Task<ActionResult<Order>> PostUser([FromQuery] int clientId,
			[FromBody] IEnumerable<Product> listProducts)
		{
			await _orderService.AddNewOrderAsync(clientId, listProducts);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Order>> DeleteOrder(int id)
		{
			await _orderService.RemoveOrderAsync(id);

			return Ok();
		}


		[HttpPost("pay")]
		public async Task<ActionResult> PayOrder([FromQuery]string email, string token)
		{
			//var charges = new ChargeService();

			//var options = new CustomerCreateOptions
			//{
			//	Email = email,
			//	Name = "Andrew",
			//	Description = "Customer for andrew@example.com",
			//	Source = "tok_visa" // demo Card
			//};
			//var service = new CustomerService();
			//var customers = await service.ListAsync();
			//foreach (var item in customers)
			//{
			//	if (Initialize.CurrentListOfUsers.Any(x => x.FirstName == item.Name))
			//	{
			//		service.Update(item.Id, new CustomerUpdateOptions
			//		{
			//			Email = "blabla23@mail.com"
			//		});
			//	}
			//}

            var reciavedInvoices = new InvoiceService();

			var a = await reciavedInvoices.ListAsync(new InvoiceListOptions
			{
				Customer = "cus_GQ4bm3Gzhma2oQ"
			});

            var items = new InvoiceItemService();

            var item = items.Create(new InvoiceItemCreateOptions
			{
				Customer = "cus_GQ4bm3Gzhma2oQ",
				Amount = 7000,
				Currency = "usd",
				Description = "A la carte AH"
			});
			var item1 = items.Create(new InvoiceItemCreateOptions
			{
				Customer = "cus_GQ4bm3Gzhma2oQ",
				Amount = 1000,
				Currency = "usd",
				Description = "Shower"
			});
			var item2 = items.Create(new InvoiceItemCreateOptions
			{
				Customer = "cus_GQ4bm3Gzhma2oQ",
				Amount = 10000,
				Currency = "usd",
				Description = "MonthlyPlan"
			});

			var invoices = new InvoiceService();

            var newInvoice = invoices.Create(new InvoiceCreateOptions
            {
                Customer = "cus_GQ4bm3Gzhma2oQ",
                AutoAdvance = true
            });

            //var customer = service.Create(options);
			//var charge = charges.Create(new ChargeCreateOptions
			//{
			//	Amount = 300,
			//	Currency = "usd",
			//	Customer = customer.Id
			//});
			return Ok();
		}
	}
}