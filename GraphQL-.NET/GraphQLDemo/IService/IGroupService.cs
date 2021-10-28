using GraphQLDemo.Models;
using System.Linq;

namespace GraphQLDemo.IService
{
    public interface IGroupService
    {
        IQueryable<Group> GetAll();
    }
}
