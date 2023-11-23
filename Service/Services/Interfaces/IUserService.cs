using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IUserService
	{
        public void Register(User newUser);
        public bool Login(string checkEmail, string checkPassword);
        public List<User> GetAll();

    }
}

