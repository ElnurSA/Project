using System;
using System.Text.RegularExpressions;
using Domain.Models;
using Repository.Data;
using Service.Helpers.Constants;
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
            nameInput: Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();

            bool isNameCorrect = false;

            if (string.IsNullOrEmpty(name))
            {
                isNameCorrect = false;
                Console.WriteLine("You must enter your name!");
                goto nameInput;
            }
            if(Regex.Match(name, "^[a-zA-Z][a-zA-Z]+$").Success)
            {
                isNameCorrect = true;
            }

            if (!isNameCorrect)
            {
                Console.WriteLine("You name cannot contain any numbers!");
                goto nameInput;
            }

            surnameInput:  Console.WriteLine("Enter your surname: ");
            string surname = Console.ReadLine();

            bool isSurnameCorrect = false;

            if (string.IsNullOrEmpty(surname))
            {
                isNameCorrect = false;
                Console.WriteLine("You must enter your surname!");
                goto surnameInput;
            }
            if (Regex.Match(surname, "^[a-zA-Z][a-zA-Z]+$").Success)
            {

                isSurnameCorrect = true;

            }

            if (!isSurnameCorrect)
            {
                Console.WriteLine("You surname cannot contain any numbers!");
                goto surnameInput;
            }

            ageInput: Console.WriteLine("Enter you age: ");
            string ageStr = Console.ReadLine();

            int age;
            bool isAgeStr = int.TryParse(ageStr, out age);

            if (!isAgeStr)
            {
                Console.WriteLine("Age must be a number, please enter a number!");
                goto ageInput;
            }

            if (age is 0)
            {
                Console.WriteLine("Age cannot be 0, please try again: ");
                goto ageInput;
            }

            if (age > 100)
            {
                Console.WriteLine("Your age cannot be higher than 100");
                goto ageInput;
            }

            if (age < 18)
            {
                Console.WriteLine("Your age cannot be less than 18");
                goto ageInput;
            }
            Email:  Console.WriteLine("Enter your email: ");
			string email = Console.ReadLine();
            bool isTrueEmail = false;
            if (Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                isTrueEmail = true;
            }

            if (!isTrueEmail)
            {
                Console.WriteLine("Your email format is wrong");
                goto Email;
            }

            passwodInput:  Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            bool isPasswordFormatCorrect = false;
            if(Regex.Match(password, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").Success) 
            {
                isPasswordFormatCorrect = true;
            }
            if (!isPasswordFormatCorrect)
            {
                Console.WriteLine("Your password format is wrong, please try again");
                goto passwodInput;
            }
            

            Console.WriteLine("Confirm your password");
            string confirmPassword = Console.ReadLine();

            if (confirmPassword != password)
            {
                Console.WriteLine("Confirm password was not identical, please try again!");
                goto passwodInput;
            }


            User user = new()
            {
                Email = email,
                Password = password,
                Age = age,
                Name = name,
                Surname = surname
            };


            var users = _data.GetAll();

           

            _data.Register(user);

            Console.WriteLine("Register Success");
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
            Email: Console.WriteLine("Add your email: ");
            string email = Console.ReadLine();
            bool isTrueEmail = false;
            if (Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                isTrueEmail = true;
            }

            if (!isTrueEmail)
            {
                Console.WriteLine("Your email format is wrong");
                goto Email;
            }

            Console.WriteLine("Add your password: ");
            passwodInput:  string password = Console.ReadLine();

            bool isSuccessLogin = _data.Login(email, password);

            if (isSuccessLogin)
            {
                Console.WriteLine("Login success, welcome to our application");
            }
            else
            {
                Console.WriteLine("Email or password is wrong, please try again: ");
                goto Email;
            }

           
            
        }
	}
}

