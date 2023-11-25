using System;
using Domain.Models;

namespace Repository.Repositories.Interfaces
{
	public interface IBaseRepositories<T>
	{
		public void Create(T entity);
		public void Delete(T entity);
		public T GetById(int id);
		public List<T> GetAll();
		

	}
}

