using Apep.Application.Contracts.Persistence;
using Apep.Application.Features.MediaItems.ViewModels;
using Apep.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Apep.Application.Features.MediaItems.Queries.GetMediaItemsList
{
    public class GetMediaItemListQueryHandler : IRequestHandler<GetMediaItemListQuery, List<MediaItemListViewModel>>
    {
        private readonly IAsyncRepository<MediaItem> _mediaRepository;
        private readonly IMapper _mapper;

        public GetMediaItemListQueryHandler(IMapper mapper, IAsyncRepository<MediaItem> mediaRepository)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }

        public async Task<List<MediaItemListViewModel>> Handle(GetMediaItemListQuery request, CancellationToken cancellationToken)
        {
            var allMediaItems = (await _mediaRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<MediaItemListViewModel>>(allMediaItems);
        }
    }
}
