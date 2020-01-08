using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SomeCompanyEmployees.Entities;
using SomeCompanyEmployees.Models;
using SomeCompanyEmployees.Services.Interfaces;

namespace SomeCompanyEmployees.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserForTableView>>> GetUsersForTableView()
		{
			var listOfUsersForTableView = await _userService.GetUsersForTableViewAsync();
			if (listOfUsersForTableView == null)
			{
				return NotFound();
			}
			return Ok(listOfUsersForTableView);
		}

		[HttpGet("user/{id}")]
		public async Task<ActionResult<UserInfo>> GetUser(int id)
		{
			var currentUser = await _userService.FindUserById(id);

			if (currentUser == null)
			{
				return NotFound();
			}

			return Ok(currentUser);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(int id, UserInfo userInfo)
		{
			if (id != userInfo.Id)
			{
				return BadRequest();
			}

			try
			{
				await _userService.EditUserAsync(userInfo);
			}
			catch (ArgumentNullException)
			{
				if (!_userService.IsUserExists(id))
				{
					return NotFound();
				}
			}

			return Ok();
		}

		[HttpPost]
		public async Task<ActionResult<UserInfo>> PostUser(UserInfo userInfo)
		{
			await _userService.AddNewUserAsync(userInfo);

			return CreatedAtAction("GetUser", new { id = userInfo.Id }, userInfo);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<UserInfo>> DeleteUser(int id)
		{
			await _userService.RemoveUserAsync(id);

			return Ok();
		}
	}
}
