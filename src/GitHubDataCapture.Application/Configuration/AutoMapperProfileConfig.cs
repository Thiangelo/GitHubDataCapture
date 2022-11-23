using AutoMapper;
using GitHubDataCapture.Application.DTO;
using GitHubDataCapture.Domain.Models;

namespace GitHubDataCapture.Application.Configuration
{
    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<Item, RepositoryBasicDataDTO>()
                .ForMember(destination => destination.Login, opt => opt.MapFrom(source => source.Owner.Login));
        }
    }
}
