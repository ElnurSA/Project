using System;
using Domain.Models;
using Repository.Data;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseApp.Controllers
{
	public class UserController
	{
        private IUserService _data;
        

        public UserController()
        {
            _data = new UserService();
        }

        

        public void Register()
		{

            Email:  Console.WriteLine("Enter your email: ");
			string email = Console.ReadLine();
            if (!email.Contains("@"))
            {
                Console.WriteLine("Email must contain @! Please try again ");
                goto Email;
            }

            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            confirm: Console.WriteLine("Confirm your password");
            string confirmPassword = Console.ReadLine();

            if (confirmPassword != password)
            {
                Console.WriteLine("Confirm password was not identical, please try again!");
                goto confirm;
            }

            Console.WriteLine("Enter your age: ");
            string age = Console.ReadLine();
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Register success!");

            int resAge;

            bool isTrueInt = int.TryParse(age, out resAge);

            User user = new()
            {
                Email = email,
                Password = password,
                Age = resAge,
                Name = name,
                Surname = surname
            };
            

            var users = _data.GetAll();

           

            _data.Register(user);
        }

        public void GetAll()
        {
            var allData = _data.GetAll();

            foreach (var item in allData)
            {
                Console.WriteLine($"{item.Name} - {item.Surname} - {item.Email} - {item.Age}");
            }
        }

        public void Login()
        {
            Login:  Console.WriteLine("Add your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Add your password: ");
            string password = Console.ReadLine();

            bool isSuccessLogin = _data.Login(email, password);

            if (isSuccessLogin)
            {
                Console.WriteLine("Login success, welcome to our application");
            }
            else
            {
                Console.WriteLine("Email or password is wrong, please try again: ");
                goto Login;
            }

           
            
        }
	}
}

