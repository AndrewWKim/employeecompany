using SomeCompanyEmployees.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeCompanyEmployees.Initiation;
using SomeCompanyEmployees.Models;

namespace SomeCompanyEmployees.Repositories
{
	public class UserRepository : IUserRepository
	{
		public async Task<IEnumerable<UserInfo>> GetUsersAsync()
		{
			return await Task.Run(() => Initialize.CurrentListOfUsers.Select(x => x));
		}

		public async Task<UserInfo> FindUserById(int id)
		{
			if (!IsUserExists(id))
			{
				return null;
			}
			return await Task.Run(() => Initialize.CurrentListOfUsers.First(x => x.Id == id));
		}

		public async Task AddNewUserAsync(UserInfo userInfo)
		{
			await Task.Run(() => Initialize.CurrentListOfUsers.Add(userInfo));
		}

		public async Task RemoveUserAsync(int id)
		{
			var userToDelete = Initialize.CurrentListOfUsers.First(x => x.Id == id);
			await Task.Run(() => Initialize.CurrentListOfUsers.Remove(userToDelete));
		}

		public async Task EditUserAsync(UserInfo userInfo)
		{
			await Task.Run(() => Initialize.CurrentListOfUsers[Initialize.CurrentListOfUsers.FindIndex(ind => ind.Id == userInfo.Id)] = userInfo);
		}

		public Boolean IsUserExists(int id)
		{
			return Initialize.CurrentListOfUsers.Any(e => e.Id == id);
		}
	}
}
