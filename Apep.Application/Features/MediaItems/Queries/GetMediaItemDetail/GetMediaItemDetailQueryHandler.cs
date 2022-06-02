using Apep.Application.Contracts.Persistence;
using Apep.Application.Features.MediaItems.ViewModels;
using Apep.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Apep.Application.Features.MediaItems.Queries.GetMediaItemDetail
{
    public class GetMediaItemDetailQueryHandler : IRequestHandler<GetMediaItemDetailQuery, MediaItemDetailViewModel>
    {
        private readonly IAsyncRepository<MediaItem> _mediaItemRepository;
        private readonly IMapper _mapper;

        public GetMediaItemDetailQueryHandler(IMapper mapper, IAsyncRepository<MediaItem> mediaItemRepository)
        {
            _mapper = mapper;
            _mediaItemRepository = mediaItemRepository; 
        }

        public async Task<MediaItemDetailViewModel> Handle(GetMediaItemDetailQuery request, CancellationToken cancellationToken)
        {
            var @mediaItem = await _mediaItemRepository.GetByIdAsync(request.Id);
            var mediaDetailDto = _mapper.Map<MediaItemDetailViewModel>(@mediaItem);
            return mediaDetailDto;
        }
    }
}
