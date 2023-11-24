using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IGroupRepository : IBaseRepositories<Groups>
	{
		public List<Groups> SortByAsc();
        public List<Groups> SortByDesc();
        public List<Groups> Search(string searchStr);
    }
}

