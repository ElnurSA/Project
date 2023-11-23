using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IUserRepository 
	{
        public void Register(User newUser);
        public List<User> GetAll();

    }
}

