using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_API.Data;
using Practice_API.Interfaces.Manager;
using Practice_API.Manager;
using Practice_API.Models;
using System.Net;
using System.Text;

namespace Practice_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController : BaseController
    {
        //private readonly ApplicationDbContext _context;
        IPostManager _postManager;
        public PostsController(IPostManager postManager)
        {
            //_context = context;
            //_postManager = new PostManager(context);
            _postManager = postManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allPosts = await _postManager.GetAllAsync();
                return CustomResult("Data Loaded Successfully !", allPosts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddPost(Post post)
        {
            try
            {
                post.CreatedDate = DateTime.Now;
                bool isSaved = await _postManager.AddAsync(post);
                //await _context.Posts.AddAsync(post);
                //bool isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    return CustomResult("Record Created Successfully !", post);
                }
                return null;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<Post> GetById(int id)
        {
            var post = await _postManager.GetbyId(id);
            return post;
        }
        [HttpPut]
        public async Task<Post> Updatepost(Post post)
        {
            if (post.Id == 0)
            {
                return null;
            }
            bool isUpdated = await _postManager.UpdateAsync(post);
            if (isUpdated)
            {
                return post;
            }
            return post;
        }
        [HttpDelete]
        public async Task<String> Delete(int id)
        {
            var postInDb = await _postManager.GetbyId(id);
            if (postInDb == null)
            {
                return "Somthing Went Wrong !";
            }
            bool isDelete = await _postManager.DeleteAsync(postInDb);
            if (isDelete)
            {
                return "Data Deleted Successfully !";
            }
            return "Failed to Delete !";
        }

    }
}
