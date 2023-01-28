using AutoMapper;
using Posts.Bll.Interfaces;
using Posts.Common.Dtos;
using Posts.Dal.Interfaces;
using Posts.Domain;

namespace Posts.Bll.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public PostService(IRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PostDto>> GetPostsAsync()
        {
            var records = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PostDto>>(records);
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            var result = _mapper.Map<PostDto>(post);
            return result;
        }

        public async Task<PostDto> CreatePostAsync(CreatePostDto dto)
        {
            var post = _mapper.Map<Post>(dto);
            await _postRepository.AddAsync(post);
            var result = _mapper.Map<PostDto>(post);
            return result;
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            await _postRepository.DeleteAsync(post);
        }
    }
}
