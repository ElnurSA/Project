using System;
using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class StudentRepository : BaseRepositories<Student>, IStudentRepository
    {
        public Student Edit(int id, Student student)
        {
            return AppDbContext<Student>.data.FirstOrDefault(m => m.Id == id);
        }

        public List<Student> FilterAsc()
        {
            return AppDbContext<Student>.data.OrderBy(m=>m.Age).ToList();
        }

        public List<Student> FilterDesc()
        {
            return AppDbContext<Student>.data.OrderByDescending(m => m.Age).ToList();
        }

        public List<Student> Search(string searchStr)
        {
            return AppDbContext<Student>.data.Where(m => m.FullName.Contains(searchStr)).ToList();
        }
    }
}

