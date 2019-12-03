using System;
using System.Collections.Generic;
using SomeCompanyEmployees.Entities;
using SomeCompanyEmployees.Models;

namespace SomeCompanyEmployees.Initiation
{
	public static class Initialize
	{
		public static List<UserInfo> CurrentListOfUsers = new List<UserInfo>();

		public static void InitializeUsers()
		{
			var jim = new UserInfo();
			jim.FirstName = "Jim";
			jim.LastName = "Smith";
			jim.Patronymic = "Gogolevich";
			jim.Age = 25;
			jim.Position = "Developer";
			jim.Gender = Gender.Male.ToString();
			jim.RegistrationDate = DateTime.Now;
			jim.LastUpdateDate = DateTime.Now;
			CurrentListOfUsers.Add(jim);

			var pol = new UserInfo();
			pol.FirstName = "Pol";
			pol.LastName = "Smith";
			pol.Patronymic = "Gogolevich";
			pol.Age = 35;
			pol.Position = "Developer";
			pol.Gender = Gender.Male.ToString();
			pol.RegistrationDate = DateTime.Now;
			pol.LastUpdateDate = DateTime.Now;
			CurrentListOfUsers.Add(pol);

			var nina = new UserInfo();
			nina.FirstName = "Nina";
			nina.LastName = "Smith";
			nina.Patronymic = "Gogolevich";
			nina.Age = 25;
			nina.Position = "Developer";
			nina.Gender = Gender.Female.ToString();
			nina.RegistrationDate = DateTime.Now;
			nina.LastUpdateDate = DateTime.Now;
			CurrentListOfUsers.Add(nina);

			var galia = new UserInfo();
			galia.FirstName = "Galia";
			galia.LastName = "Smith";
			galia.Patronymic = "Gogolevich";
			galia.Age = 25;
			galia.Position = "Developer";
			galia.Gender = Gender.Female.ToString();
			galia.RegistrationDate = DateTime.Now;
			galia.LastUpdateDate = DateTime.Now;
			CurrentListOfUsers.Add(galia);

			var anna = new UserInfo();
			anna.FirstName = "Anna";
			anna.LastName = "Smith";
			anna.Patronymic = "Gogolevich";
			anna.Age = 18;
			anna.Position = "Developer";
			anna.Gender = Gender.Female.ToString();
			anna.RegistrationDate = DateTime.Now;
			anna.LastUpdateDate = DateTime.Now;
			CurrentListOfUsers.Add(anna);

			var max = new UserInfo();
			max.FirstName = "Max";
			max.LastName = "Smith";
			max.Patronymic = "Gogolevich";
			max.Age = 25;
			max.Position = "Developer";
			max.Gender = Gender.Male.ToString();
			max.RegistrationDate = DateTime.Now;
			max.LastUpdateDate = DateTime.Now;
			CurrentListOfUsers.Add(max);

			var ford = new UserInfo();
			ford.FirstName = "Ford";
			ford.LastName = "Smith";
			ford.Patronymic = "Gogolevich";
			ford.Age = 25;
			ford.Position = "Developer";
			ford.Gender = Gender.Male.ToString();
			ford.RegistrationDate = DateTime.Now;
			ford.LastUpdateDate = DateTime.Now;
			CurrentListOfUsers.Add(ford);

			var curt = new UserInfo();
			curt.FirstName = "Curt";
			curt.LastName = "Smith";
			curt.Patronymic = "Gogolevich";
			curt.Age = 67;
			curt.Position = "Developer";
			curt.Gender = Gender.Male.ToString();
			curt.RegistrationDate = DateTime.Now;
			curt.LastUpdateDate = DateTime.Now;
			CurrentListOfUsers.Add(curt);
		}
	}
}
