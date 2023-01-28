using Posts.Common.Dtos;

namespace Posts.Bll.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task<PostDto> CreatePostAsync(CreatePostDto dto);
        Task DeletePostAsync(int id);
    }
}
