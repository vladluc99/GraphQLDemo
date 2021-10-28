using GraphQLDemo.IService;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL
{
    public class Mutation
    {
        private readonly IStudentService _studentService;

        public Mutation(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public Student CreateStudent(CreateStudentInput inputStudent)
        {
            return _studentService.Create(inputStudent);
        }

        public Student DeleteStudent(DeleteStudentInput inputStudent)
        {
            return _studentService.Delete(inputStudent);
        }
    }
}
