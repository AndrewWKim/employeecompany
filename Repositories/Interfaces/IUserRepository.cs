using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SomeCompanyEmployees.Models;

namespace SomeCompanyEmployees.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<UserInfo>> GetUsersAsync();
		Task<UserInfo> FindUserById(int id);
		Task AddNewUserAsync(UserInfo userInfo);
		Task RemoveUserAsync(int id);
		Task EditUserAsync(UserInfo userInfo);
		Boolean IsUserExists(int id);
	}
}
