using EF.Core.Repository.Interface.Manager;
using Practice_API.Models;

namespace Practice_API.Interfaces.Manager
{
    public interface IPostManager : ICommonManager<Post>
    {
        public Task<Post> GetbyId(int id);
    }
}
