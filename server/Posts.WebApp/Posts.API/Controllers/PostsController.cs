using Microsoft.AspNetCore.Mvc;
using Posts.Bll.Interfaces;
using Posts.Common.Dtos;

namespace Posts.API.Controllers
{
    [Route("api/posts")]
    public class PostsController : AppBaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> GetPostsAsync()
        {
            var items = await _postService.GetPostsAsync();
            Response.Headers.Add("x-total-count", items.Count().ToString());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<PostDto> GetPostAsync(int id)
        {
            return await _postService.GetPostByIdAsync(id);
        }

        [HttpPost]
        public async Task<PostDto> CreatePostAsync([FromBody] CreatePostDto postDto)
        {
            return await _postService.CreatePostAsync(postDto);
        }

        [HttpDelete("{id}")]
        public async Task DeletePostAsync(int id)
        {
            await _postService.DeletePostAsync(id);
        }
    }
}

