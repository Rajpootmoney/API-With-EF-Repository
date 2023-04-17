using EF.Core.Repository.Repository;
using Practice_API.Data;
using Practice_API.Interfaces.Repository;
using Practice_API.Models;

namespace Practice_API.Repository
{
    public class PostRepository : CommonRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
