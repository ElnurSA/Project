using System;
using Domain.Models;

namespace Service.Services.Interfaces
{
	public interface IStudentService
    {
		public void Create(Student student);
		public void Delete(Student student);
		public void Edit();
		public Student GetById(int id);
		public List<Student> GetAll();
		public List<Student> FilterAsc();
		public List<Student> Search(string searchStr);
		public List<Student> FilterDesc();


    }
}

