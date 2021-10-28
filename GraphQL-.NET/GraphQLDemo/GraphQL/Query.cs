using GraphQLDemo.IService;
using GraphQLDemo.Models;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLDemo.GraphQL
{
    public class Query
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public Query(IGroupService groupService, IStudentService studentService)
        {
            _groupService = groupService;
            _studentService = studentService;
        }

        [UsePaging(SchemaType = typeof(GroupType))]
        [UseFiltering]
        public IQueryable<Group> Groups => _groupService.GetAll();
        [UsePaging(SchemaType = typeof(StudentType))]
        [UseFiltering]
        public IQueryable<Student> Students => _studentService.GetAll();
    }
}
