using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepositories<Groups>, IGroupRepository
    {
        public List<Groups> Search(string searchStr)
        {
            return AppDbContext<Groups>.data.Where(m => m.Name.Contains(searchStr)).ToList();
        }

        public List<Groups> SortByAsc()
        {
            return AppDbContext<Groups>.data.OrderBy(m => m.Capacity).ToList();
        }

        public List<Groups> SortByDesc()
        {
            return AppDbContext<Groups>.data.OrderByDescending(m => m.Capacity).ToList();
        }
    }
}

