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

        public void Edit(int id, Student student)
        {
            Student existingStudent = _student.Edit(id, student);
            if (!string.IsNullOrWhiteSpace(student.FullName))
            {
                existingStudent.FullName = student.FullName;
            }

            if (student.Age is not 0)
            {
                existingStudent.Age = student.Age;
            }

            if (!string.IsNullOrWhiteSpace(student.Address))
            {
                existingStudent.Address = student.Address;
            }

            if (student.Group == null)
            {
                existingStudent.Group = student.Group;
            }

            
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

