using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class BaseRepositories<T> : IBaseRepositories<T> where T:BaseEntity
    {
        
        public void Create(T entity)
        {
            
            AppDbContext<T>.data.Add(entity);

        }

        public void Delete(T entity)
        {
            AppDbContext<T>.data.Remove(entity);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return AppDbContext<T>.data;
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.data.FirstOrDefault(m => m.Id == id);
        }

        
    }
}

