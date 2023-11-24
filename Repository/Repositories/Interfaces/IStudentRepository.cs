using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IStudentRepository : IBaseRepositories<Student>
	{
		public List<Student> FilterAsc();
        public List<Student> FilterDesc();
        public List<Student> Search(string searchStr);
	}
}

