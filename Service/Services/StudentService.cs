using System;
using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _student;

		public StudentService()
		{
			_student = new StudentRepository();
		}

        public void Create(Student student)
        {
            _student.Create(student);
        }

        public void Delete(Student student)
        {
            _student.Delete(student);
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public List<Student> FilterAsc()
        {
            return _student.FilterAsc();
        }

        public List<Student> FilterDesc()
        {
            return _student.FilterDesc();
        }

        public List<Student> GetAll()
        {
            return _student.GetAll();
        }

        public Student GetById(int id)
        {
            return _student.GetById(id);
        }

        public List<Student> Search(string searchStr)
        {
            return _student.Search(searchStr);
        }
    }
}

