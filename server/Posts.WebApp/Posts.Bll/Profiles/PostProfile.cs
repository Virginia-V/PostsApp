using AutoMapper;
using Posts.Common.Dtos;
using Posts.Domain;

namespace Posts.Bll.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<CreatePostDto, Post>();
        }
    }
}
