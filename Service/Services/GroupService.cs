using System;
using System.Text.RegularExpressions;
using Domain.Models;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class GroupService : IGroupService
	{
        private readonly IGroupRepository _repo;

		public GroupService()
		{
            _repo = new GroupRepository();
		}

        public void Create(Groups group)
        {
            _repo.Create(group);
        }

        public void Delete(Groups group)
        {
            _repo.Delete(group);
        }

        public void Edit(int id, Groups group)
        {
            Groups existingGroup = _repo.Edit(id, group);
            if(!string.IsNullOrWhiteSpace(group.Name))
            {
                existingGroup.Name = group.Name;
            }
            
            if (group.Capacity is not 0)
            {
                existingGroup.Capacity = group.Capacity;
            }
            

        }

        public List<Groups> GetAll()
        {
            return _repo.GetAll();
        }

        public Groups GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Groups> Search(string search)
        {
            return _repo.Search(search);
        }

        public List<Groups> SortByAsc()
        {
            return _repo.SortByAsc();
        }

        public List<Groups> SortByDesc()
        {
            return _repo.SortByDesc();
        }
    }
}

