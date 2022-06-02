using Apep.Application.Features.MediaItems.Commands.CreateMediaItem;
using Apep.Application.Features.MediaItems.ViewModels;
using Apep.Domain.Entities;
using AutoMapper;

namespace Apep.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<MediaItem, MediaItemListViewModel>();
            CreateMap<MediaItem, MediaItemDetailViewModel>();
            CreateMap<MediaItem, CreateMediaItemCommand>();
        }
    }
}
