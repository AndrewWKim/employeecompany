using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

		private static int globalUserID = 0;

		public UserInfo()
		{
			Id = Interlocked.Increment(ref globalUserID);
		}
	}
}
