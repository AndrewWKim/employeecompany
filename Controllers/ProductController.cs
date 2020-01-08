using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SomeCompanyEmployees.Initiation;
using SomeCompanyEmployees.Models;

namespace SomeCompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
	    [HttpGet]
	    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
	    {
		    var listOfProducts = await Task.Run(() => Initialize.CurrentListOfProducts);
		    if (listOfProducts == null)
		    {
			    return NotFound();
		    }
		    return Ok(listOfProducts);
	    }
	}
}