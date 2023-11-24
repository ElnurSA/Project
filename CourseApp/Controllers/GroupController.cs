using System;
using System.Text.RegularExpressions;
using Domain.Models;
using Service.Services;
using Service.Services.Interfaces;

namespace CourseApp.Controllers
{
	public class GroupController
	{
		public IGroupService _groups;

		public GroupController()
		{
			_groups = new GroupService();
		}

		public void GetAll()
		{
			var data = _groups.GetAll();

			foreach (var group in data)
			{
				Console.WriteLine($"{group.Name} - {group.Capacity} - {group.Id}");
			}
		}

		public void GetById()
		{
            input:  Console.WriteLine("Please enter Id: ");
			string idStr = Console.ReadLine();
			int id;

			bool isTrueInt = int.TryParse(idStr, out id);

			if (!isTrueInt)
			{
				Console.WriteLine("Your input must be a number! Please try again.");
				goto input;
			}

			if(_groups.GetById(id) == null)
			{
				Console.WriteLine("There isn't any group with this Id, please try again: ");
                goto input;
            }


			Console.WriteLine(_groups.GetById(id));
		}
		private static int id = 1;
		public void Create()
		{
			Console.WriteLine("To create a group please enter the followings: ");
			Console.WriteLine("Group Name: ");
			string groupName = Console.ReadLine();

            capacityLine:  Console.WriteLine("Group Capacity: ");
			string capacityStr = Console.ReadLine();
			int capacity;
			bool isCapacityInt = int.TryParse(capacityStr, out capacity);

			if (!isCapacityInt)
			{
				Console.WriteLine("Your input is wrong, please enter a number!");
				goto capacityLine;
			}

			Groups newGroup = new() { Name = groupName, Capacity = capacity, Id = id };

			id++;
			_groups.Create(newGroup);

			Console.WriteLine("Group created successfully");

		}

		public void Delete()
		{
            Console.WriteLine("Choose 1 if you want to continue, or 2 if you want to go back: ");
            string intInput = Console.ReadLine();

            if (intInput == "2")
            {
                return;
            }

            Console.WriteLine("Please enter the name of the group, which you want to delete: ");
			string groupName = Console.ReadLine();

			var allGroups = _groups.GetAll();

			Groups groupDelete = allGroups.FirstOrDefault(m => m.Name.Contains(groupName));

			_groups.Delete(groupDelete);

		}

		public void Sort()
		{
            choice:  Console.WriteLine("Please enter 1 to sort by ascending, or 2 to sort by descending: ");
			string inputStr = Console.ReadLine();
			int input;

			bool isInt = int.TryParse(inputStr, out input);

			if (!isInt)
			{
				Console.WriteLine("Your input must be a number! Please try again: ");
				goto choice;
			}

			if (input > 2 || input < 1)
			{
				Console.WriteLine("You must choose either 1 or 2! Please try again: ");
                goto choice;
            }

			if(input == 1)
			{
				var data = _groups.SortByAsc();
				foreach (var group in data)
				{
					Console.WriteLine($"{group.Name} - {group.Capacity}");
				}
			}

            if (input == 2)
            {
                var data = _groups.SortByDesc();
                foreach (var group in data)
                {
                    Console.WriteLine($"{group.Name} - {group.Capacity}");
                }
            }
        }

		public void Search()
		{
            input:  Console.WriteLine("Enter search for group name: ");
			string search = Console.ReadLine();


			var data = _groups.Search(search);

			foreach (var group in data)
			{
				Console.WriteLine($"{group.Name} - {group.Capacity}");
			}

			if(data == null)
			{
				Console.WriteLine("No group has been found please try again: ");
				goto input;
			}
		}
	}
}

