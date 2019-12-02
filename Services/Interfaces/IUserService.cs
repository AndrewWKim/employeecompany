using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeCompanyEmployees.Entities;
using SomeCompanyEmployees.Models;

namespace SomeCompanyEmployees.Services.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserForTableView>> GetUsersForTableViewAsync();
		Task<UserInfo> FindUserById(int id);
		Task AddNewUserAsync(UserInfo userInfo);
		Task RemoveUserAsync(int id);
		Task EditUserAsync(UserInfo userInfo);
		Boolean IsUserExists(int id);
	}
}
