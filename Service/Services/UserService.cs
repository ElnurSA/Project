using System;
using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;

        public UserService()
        {
            _user = new UserRepository();
        }

        public List<User> GetAll()
        {
            return _user.GetAll();
        }

        public bool Login(string checkEmail, string checkPassword)
        {
            var users = _user.GetAll();
            
            bool isLoginSuccess = false;

            foreach (var item in users)
            {
                if ( item.Email == checkEmail && item.Password == checkPassword)
                {
                    isLoginSuccess = true;
                    break;
                }
            }

            
            return isLoginSuccess;
        }

        public void Register(User newUser)
        {
            _user.Register(newUser);
        }
         

        
    }
}

