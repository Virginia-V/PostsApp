using AutoMapper;
using Posts.Bll.Interfaces;
using Posts.Common.Dtos;
using Posts.Dal.Interfaces;
using Posts.Domain;

namespace Posts.Bll.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var records = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(records);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userRepository.AddAsync(user);
            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public async Task DeleteUserAsync(int id)
        {
            var post = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(post);
        }
    }
}
