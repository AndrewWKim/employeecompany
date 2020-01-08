using System;
using System.Threading;

namespace SomeCompanyEmployees.Models
{
	public class UserInfo
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Patronymic { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }
		public string Position { get; set; }
		public DateTime RegistrationDate { get; set; }
		public DateTime LastUpdateDate { get; set; }

		private static int _globalUserId;

		public UserInfo()
		{
			Id = Interlocked.Increment(ref _globalUserId);
		}
	}
}
