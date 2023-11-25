using System;
using System.Text.RegularExpressions;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IGroupService
	{
        //Group operations: 1-Create, 2-Delete, 3-Edit, 4-GetById, 5-GetAll, 6-Search, 7-Sorting
        public void Create(Groups group);
        public void Delete(Groups group);
        public void Edit(int id, Groups group);
        public Groups GetById(int id);
        public List<Groups> GetAll();
        public List<Groups> Search(string search);
        public List<Groups> SortByAsc();
        public List<Groups> SortByDesc();
    }
}

