using GraphQLDemo.Except;
using GraphQLDemo.IService;
using GraphQLDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDemo.Service
{
    public class StudentService : IStudentService
    {
        private IList<Student> _students;
        public StudentService()
        {
            _students = new List<Student>()
            {
                new Student() { StudentID = 1, Name = "Vlad", GroupID = 1},
                new Student() { StudentID = 2, Name = "Andrei", GroupID = 2},
                new Student() { StudentID = 3, Name = "Sabin", GroupID = 3},
                new Student() { StudentID = 4, Name = "Marian", GroupID = 1},
                new Student() { StudentID = 5, Name = "Vlad", GroupID = 3}
            };
        }
        public Student Create(CreateStudentInput inputStudent)
        {
            var student = new Student()
            {
                StudentID = _students.Max(x => x.StudentID) + 1,
                Name = inputStudent.Name,
                GroupID = inputStudent.GroupId
            };
            _students.Add(student);
            return student;
        }

        public Student Delete(DeleteStudentInput inputStudent)
        {
            var student = _students.FirstOrDefault(x => x.StudentID == inputStudent.StudentId);
            if (student == null) throw new StudentNotFoundException() { StudentId = inputStudent.StudentId };
            _students.Remove(student);
            return student;
        }

        public IQueryable<Student> GetAll()
        {
            return _students.AsQueryable();
        }
    }
}
