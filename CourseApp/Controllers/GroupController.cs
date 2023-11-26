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

			var datas = _groups.GetById(id);

			Console.WriteLine($"{datas.Name} - {datas.Capacity} - {datas.Id}");
		}
		private static int id = 1;
		public void Create()
		{
			Console.WriteLine("To create a group please enter the followings: ");
            nameLine:  Console.WriteLine("Group Name: ");
			string groupName = Console.ReadLine();
			var data = _groups.GetAll();

			if (data.FirstOrDefault(m=>m.Name == groupName) != null)
			{
				Console.WriteLine("Group with this name already exists! Please try again:");
				goto nameLine;
			}

			if (string.IsNullOrWhiteSpace(groupName))
			{
				Console.WriteLine("You must enter the name of the group!");
				goto nameLine;
			}

            capacityLine:  Console.WriteLine("Group Capacity: ");
			string capacityStr = Console.ReadLine();
			int capacity;
			bool isCapacityInt = int.TryParse(capacityStr, out capacity);

			if (string.IsNullOrWhiteSpace(capacityStr))
			{
				Console.WriteLine("You must enter capacity of the group!");
				goto capacityLine;
			}

			if (!isCapacityInt)
			{
				Console.WriteLine("Your input is wrong, please enter a number!");
				goto capacityLine;
			}

			if(capacity < 0)
			{
				Console.WriteLine("Capacity cannot be less than to 0");
				goto capacityLine;
			}

			Groups newGroup = new() { Name = groupName, Capacity = capacity, Id = id };

			id++;
			_groups.Create(newGroup);

			Console.WriteLine("Group created successfully");

			

		}

		public void Delete()
		{
            beginning:  Console.WriteLine("Choose 1 if you want to continue, or 2 if you want to go back: ");
            string intInput = Console.ReadLine();

            if (intInput == "1")
            {
                
            }
			else if(intInput == "2")
			{
				return;
			}
			else
			{
				Console.WriteLine("You must enter either 1 or 2! Try again: ");
				goto beginning;
			}


            input:  Console.WriteLine("Please enter the Id of the group, which you want to delete: ");
			string groupId = Console.ReadLine();
			int id;
			bool isIdInt = int.TryParse(groupId, out id);
			var allGroups = _groups.GetAll();

			if (string.IsNullOrWhiteSpace(groupId))
			{
				Console.WriteLine("Your input cannot be empty, please try again");
				goto input;
			}



			Groups groupDelete = _groups.GetById(id);
            

			if(groupDelete is null)
			{
				Console.WriteLine("The group with this id has not been found");
				goto input;
			}

			_groups.Delete(groupDelete);

			Console.WriteLine("Group has been deleted successfully");

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

			if (string.IsNullOrEmpty(search.ToLower().Trim()))
			{
				Console.WriteLine("Search cannot be empty");
				goto input;
			}
			
			var data = _groups.Search(search);

			foreach (var group in data)
			{
				Console.WriteLine($"{group.Name} - {group.Capacity}");
			}

			if(data.Capacity == 0)
			{
				Console.WriteLine("No group has been found ");
				
			}
		}

		public void Edit()
		{


            idInput:  Console.WriteLine("Enter the id of the group to edit: ");
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
            var groupById = _groups.GetById(id);

			if(groupById is null)
			{
				Console.WriteLine("Group with this id has not been found.");
				return;
			}

            Console.WriteLine($"{groupById.Name} - {groupById.Capacity}");

			Console.WriteLine("Enter new group name: ");
			string newGroupName = Console.ReadLine();

			Console.WriteLine("Enter new group capacity: ");
			string newCapacityStr = Console.ReadLine();
			int newCapacity;
			bool isCapacityInt = int.TryParse(newCapacityStr, out newCapacity);
			if (!isCapacityInt)
			{
				if (string.IsNullOrWhiteSpace(newCapacityStr))
				{
					goto end;
				}
				Console.WriteLine("Capacity has to be a number, please try again: ");
			}

            end:  Groups newGroup = new() { Name = newGroupName, Capacity = newCapacity, Id = id };

			_groups.Edit(id, newGroup);

			Console.WriteLine($"{groupById.Name} - {groupById.Capacity} - {groupById.Id}");
			

			

		}
	}
}

