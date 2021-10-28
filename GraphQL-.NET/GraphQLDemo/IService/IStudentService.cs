using GraphQLDemo.Models;
using System.Linq;

namespace GraphQLDemo.IService
{
    public interface IStudentService
    {
        IQueryable<Student> GetAll();
        Student Create(CreateStudentInput inputStudent);
        Student Delete(DeleteStudentInput inputStudent);
    }
}
