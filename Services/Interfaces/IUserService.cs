using System.Collections.Generic;
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
		bool IsUserExists(int id);
	}
}
