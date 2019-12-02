using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SomeCompanyEmployees.Entities;
using SomeCompanyEmployees.Models;
using SomeCompanyEmployees.Repositories.Interfaces;
using SomeCompanyEmployees.Services.Interfaces;

namespace SomeCompanyEmployees.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<IEnumerable<UserForTableView>> GetUsersForTableViewAsync()
		{
			var result = await _userRepository.GetUsersAsync();

			if (result == null)
			{
				return null;
			}
			return ConvertUsersToTableView(result);
		}

		public async Task<UserInfo> FindUserById(int id)
		{
			if (!IsUserExists(id))
			{
				return null;
			}
			return await _userRepository.FindUserById(id);
		}

		public async Task AddNewUserAsync(UserInfo userInfo)
		{
			await _userRepository.AddNewUserAsync(userInfo);
		}

		public async Task RemoveUserAsync(int id)
		{
			await _userRepository.RemoveUserAsync(id);
		}

		public async Task EditUserAsync(UserInfo userInfo)
		{
			await _userRepository.EditUserAsync(userInfo);
		}

		public Boolean IsUserExists(int id)
		{
			return _userRepository.IsUserExists(id);
		}

		private static IEnumerable<UserForTableView> ConvertUsersToTableView(IEnumerable<UserInfo> userInfos)
		{
			var result = userInfos.OrderByDescending(x => x.Id).Select(y => new UserForTableView
			{
				Id = y.Id,
				FirstName = y.FirstName,
				LastName = y.LastName,
				Age = y.Age,
				Gender = y.Gender,
			});

			return result.ToList();
		}
	}
}
