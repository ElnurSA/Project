using System;
using System.Linq;
using System.Text.RegularExpressions;
using Domain.Models;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseApp.Controllers
{
	public class StudentController
	{
		public readonly GroupService group;
		private readonly IStudentService _student;

		public StudentController()
		{
            _student = new StudentService();
			group = new GroupService();
		}

		public void GetAll()
		{
			var data = _student.GetAll();

			foreach (var student in data)
			{
				Console.WriteLine($"{student.FullName} - {student.Age} - {student.Address} - {student.Phone} - {student.Group.Name} - {student.Id}");
			}
		}

		public void GetById()
		{
            input: Console.WriteLine("Enter Id of the student");
			string numStr = Console.ReadLine();

			int num;

			bool isInt = int.TryParse(numStr, out num);

			if (!isInt)
			{
				Console.WriteLine("Your input is not valid for an Id, please try again!");
                goto input;
            }

            if (_student.GetById(num) == null)
            {
                Console.WriteLine("There isn't any studnet with this Id, please try again: ");
                goto input;
            }

            var data = _student.GetById(num);

			Console.WriteLine($"{data.FullName} - {data.Age} - {data.Address} - {data.Phone}");
		}

		public void Search()
		{
            input:  Console.WriteLine("Search for a student: ");
			string search = Console.ReadLine();

			var data = _student.Search(search);

			foreach (var student in data)
			{
				Console.WriteLine($"{student.FullName} - {student.Age} - {student.Address} - {student.Phone}");
			}

            if (data.Capacity == 0)
            {
                Console.WriteLine("No student has been found please try again: ");
                goto input;
            }
        }

		private static int capacityOfGroups= 0;
        private static int inputId = 1;
        public void Create()
		{
			
			Console.WriteLine("To create a student please input the followings:");

            nameInput: Console.WriteLine("Enter your name and surname: ");
            string fullName = Console.ReadLine();

           

            if (string.IsNullOrEmpty(fullName))
            {
                Console.WriteLine("You must enter your name!");
                goto nameInput;
            }
            //@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
            //@"^[A-Z][a-zA-Z]*$")
            if (!Regex.IsMatch(fullName, @"[A-Z][a-zA-Z]*$"))
            {
                Console.WriteLine("You name format is wrong!");
                goto nameInput;
            }

            ageInput:  Console.WriteLine("Age: ");
			string ageStr = Console.ReadLine();

			int age;
			bool isAgeStr = int.TryParse(ageStr, out age);

			if (!isAgeStr)
			{
				Console.WriteLine("Age must be a number, please enter a number!");
				goto ageInput;
			}

			if(age is 0)
			{
				Console.WriteLine("Age cannot be 0, please try again: ");
				goto ageInput;
			}

			if(age > 100)
			{
				Console.WriteLine("Your age cannot be higher than 100");
				goto ageInput;
			}

            if (age < 0)
            {
                Console.WriteLine("Your age cannot be less than 0");
                goto ageInput;
            }

            addressInput:  Console.WriteLine("Address: ");
			string address = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(address))
            {                Console.WriteLine("Your must enter your address!");
                goto addressInput;
            }

            phoneInput:  Console.WriteLine("Phone: ");
			string phone = Console.ReadLine();

			bool isPhoneFormatCorrect = false;

			if(string.IsNullOrWhiteSpace(phone))
			{
				Console.WriteLine("Your must enter your phone number!");
				goto phoneInput;
			}

			if (Regex.Match(phone, "^\\+?[1-9][0-9]{7,14}$").Success)
			{
				isPhoneFormatCorrect = true;

			}

			if (!isPhoneFormatCorrect)
			{
				Console.WriteLine("The phone number format is wrong please try again.");
				goto phoneInput;
			}

            groupLine:  Console.WriteLine("Student must be in a group. Please enter an id of a group");
			string idStr = Console.ReadLine();
			int id;
			bool isInt = int.TryParse(idStr, out id);

			if (string.IsNullOrWhiteSpace(idStr))
			{
				Console.WriteLine("You must enter id!");
				goto groupLine;
			}

			if (!isInt)
			{
				Console.WriteLine("Id must be a number please try again: ");
				goto groupLine;
			}

			if (id <= 0)
			{
				Console.WriteLine("Id cannot be less than 0 or equal to 0");
				goto groupLine;
			}

			Groups groupById = group.GetById(id);

			List<Groups> AllGroup = group.GetAll();

			if(AllGroup is null)
			{
				Console.WriteLine("You have not created any groups please come back later.");
				return;
			}

			if(groupById == null)
			{
				Console.WriteLine("Group not found please try again");
				goto groupLine;
			}

			int capacityGroup = groupById.Capacity;
			capacityGroup++;

			Student student = new() { FullName = fullName, Address = address, Age = age, Id = inputId, Phone = phone, Group = groupById };

			if(student.Group == null)
			{
				Console.WriteLine("There is no group with this Id, please try again: ");
				goto groupLine;
			}
			inputId++;

			_student.Create(student);

			Console.WriteLine("Student created successfully!");
			
		}

		public void Delete()
		{
            beginning: Console.WriteLine("Choose 1 if you want to continue, or 2 if you want to go back: ");
			string intInput = Console.ReadLine();

            if (intInput == "1")
            {

            }
            else if (intInput == "2")
            {
                return;
            }
            else
            {
                Console.WriteLine("You must enter either 1 or 2! Try again: ");
                goto beginning;
            }


            Console.WriteLine("Enter the name of a student, who you want to delete: ");
            deleteInput:  string name = Console.ReadLine();

			var data = _student.GetAll();

			Student searchRes = (Student)data.FirstOrDefault(m=>m.FullName.Contains(name));

			if(searchRes == null)
			{
				Console.WriteLine("Student has not been found!Please try again. ");
				goto deleteInput;
			}
			else
			{
				_student.Delete(searchRes);
				Console.WriteLine("Student has been deleted successfully");
			}
			
		}

		public void Filter()
		{
            Console.WriteLine("Choose 1 for filtering by ascending age and 2 for filtering by descending age: ");
            choice:  string numStr = Console.ReadLine();

			int num;

			bool isTrueNum = int.TryParse(numStr, out num);

			if (!isTrueNum)
			{
				Console.WriteLine("Your input has to be a number, please enter 1 or 2 ");
				goto choice;
			}

			if(num > 2 || num < 1)
			{
                Console.WriteLine("Your input is wrong, please enter 1 or 2 ");
                goto choice;
            }

			if (num == 1)
			{
				var data = _student.FilterAsc();

				foreach (var student in data)
				{
					Console.WriteLine($"{student.FullName} - {student.Age} - {student.Address} - {student.Phone}");
				}
			}

            if (num == 2)
            {
                var data = _student.FilterDesc();

                foreach (var student in data)
                {
                    Console.WriteLine($"{student.FullName} - {student.Age} - {student.Address} - {student.Phone}");
                }
            }

        }

		public void Edit()
		{
		idInput: Console.WriteLine("Enter the id of the student to edit: ");
			string idStr = Console.ReadLine();

			int id;
			bool isTrueInt = int.TryParse(idStr, out id);
			if (string.IsNullOrWhiteSpace(idStr))
			{
				Console.WriteLine("Please enter an id: ");
				goto idInput;
			}
			if (!isTrueInt)
			{
				Console.WriteLine("Id has to be a number, please try again: ");
				goto idInput;
			}
			var studentById = _student.GetById(id);

			if (studentById is null)
			{
				Console.WriteLine("Student with this id has not been found.");
				return;
			}

			Console.WriteLine($"{studentById.FullName} - {studentById.Age} - {studentById.Address} - {studentById.Phone} - {studentById.Id}");

			Console.WriteLine("Enter new student name: ");
			string newStudentName = Console.ReadLine();

            inputAge:  Console.WriteLine("Enter new student age: ");
			string newAgeStr = Console.ReadLine();
			int newAge;
			bool isAgeInt = int.TryParse(newAgeStr, out newAge);
			if (!isAgeInt)
			{
				if (string.IsNullOrWhiteSpace(newAgeStr))
				{
					newAge = studentById.Age;

                    goto end;
				}
				Console.WriteLine("Age has to be a number, please try again: ");
				goto inputAge;
			}

            end:  Console.WriteLine("Enter new student address: ");
			string newAddress = Console.ReadLine();

			Console.WriteLine("Enter new student number");
			string newPhone = Console.ReadLine();

            groupLine:  Console.WriteLine("Enter the Id of the new group");
			string idGroupStr = Console.ReadLine();
			int idGroup;
			bool isGroupIdInt = int.TryParse(idGroupStr, out idGroup);

			if(idGroupStr == null)
			{
				idGroup = id;
			}

			if (!isGroupIdInt)
			{
				Console.WriteLine("Id has to be a number please try again: ");
				goto groupLine;
			}

			Groups newGroup = group.GetById(idGroup);

			if (newGroup == null)
			{
				Console.WriteLine("No group with this id was found please try again: ");
				goto groupLine;
			}

			Student newStudent = new() { Id = id, FullName = newStudentName, Age = newAge, Phone = newPhone, Address = newAddress, Group = newGroup };


            _student.Edit(id, newStudent);

			




        }
    }
}

