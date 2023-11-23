using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class UserRepository : IUserRepository
	{
        public List<User> GetAll()
        {
            return AppDbContext<User>.data;
        }

        public void Register(User user)
		{
			AppDbContext<User>.data.Add(user);
        }
	}
}

