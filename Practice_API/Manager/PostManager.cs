using EF.Core.Repository.Manager;
using Practice_API.Data;
using Practice_API.Interfaces.Manager;
using Practice_API.Models;
using Practice_API.Repository;

namespace Practice_API.Manager
{
    public class PostManager : CommonManager<Post>, IPostManager
    {
        public PostManager(ApplicationDbContext _context) : base(new PostRepository(_context))
        {

        }

        public async Task<Post> GetbyId(int id)
        {
            return await GetFirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
