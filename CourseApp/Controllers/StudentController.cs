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

        private static int inputId = 1;
        public void Create()
		{
			
			Console.WriteLine("To create a student please input the followings:");

			Console.WriteLine("Name and surname:");
			string fullName = Console.ReadLine();

            ageInput:  Console.WriteLine("Age: ");
			string ageStr = Console.ReadLine();

			int age;
			bool isAgeStr = int.TryParse(ageStr, out age);

			if (!isAgeStr)
			{
				Console.WriteLine("Age must be a number, please enter a number!");
				goto ageInput;
			}

			Console.WriteLine("Address: ");
			string address = Console.ReadLine();

			Console.WriteLine("Phone: ");
			string phone = Console.ReadLine();

            groupLine:  Console.WriteLine("Student must be in a group. Please enter an id of a group");
			string idStr = Console.ReadLine();
			int id;
			bool isInt = int.TryParse(idStr, out id);

			Groups groupById = group.GetById(id);

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
			Console.WriteLine("Choose 1 if you want to continue, or 2 if you want to go back: ");
			string intInput = Console.ReadLine();

			if(intInput == "2")
			{
				return;
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
			var groupById = _student.GetById(id);

			if (groupById is null)
			{
				Console.WriteLine("Student with this id has not been found.");
				return;
			}

			Console.WriteLine($"{groupById.FullName} - {groupById.Age} - {groupById.Address} - {groupById.Phone} - {groupById.Id}");

			Console.WriteLine("Enter new student name: ");
			string newStudentName = Console.ReadLine();

			Console.WriteLine("Enter new student age: ");
			string newAgeStr = Console.ReadLine();
			int newAge;
			bool isAgeInt = int.TryParse(newAgeStr, out newAge);
			if (!isAgeInt)
			{
				if (string.IsNullOrWhiteSpace(newAgeStr))
				{
					return;
				}
				Console.WriteLine("Age has to be a number, please try again: ");
			}

			Console.WriteLine("Enter new student address: ");
			string newAddress = Console.ReadLine();

			Console.WriteLine("Enter new student number");
			string newPhone = Console.ReadLine();

            groupLine:  Console.WriteLine("Enter the Id of the new group");
			string idGroupStr = Console.ReadLine();
			int idGroup;
			bool isGroupIdInt = int.TryParse(idGroupStr, out idGroup);

			Groups newGroup = group.GetById(idGroup);

			if (newGroup == null)
			{
				Console.WriteLine("No group with this id was found please try again: ");
				goto groupLine;
			}

			Student newStudent = new() { Id = id, FullName = newStudentName, Age = newAge, Phone = newPhone, Address = newAddress, Group = newGroup };


            _student.Edit(id, newStudent);

			Console.WriteLine($"{newStudent.FullName} - {newStudent.Age} - {newStudent.Address}- {newStudent.Phone} - {newStudent.Id}");




        }
    }
}

