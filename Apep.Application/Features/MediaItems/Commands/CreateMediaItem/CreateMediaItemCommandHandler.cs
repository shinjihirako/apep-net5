using Apep.Application.Contracts.Persistence;
using Apep.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Apep.Application.Features.MediaItems.Commands.CreateMediaItem
{
    public class CreateMediaItemCommandHandler : IRequestHandler<CreateMediaItemCommand, Guid>
    {
        private readonly IMediaItemRepository _mediaRepository;
        private readonly IMapper _mapper;

        public CreateMediaItemCommandHandler(IMapper mapper, IMediaItemRepository mediaItemRepository)
        {
            _mapper = mapper;
            _mediaRepository = mediaItemRepository; 
        }
        public async Task<Guid> Handle(CreateMediaItemCommand request, CancellationToken cancellationToken)
        {
            var @mediaItem = _mapper.Map<MediaItem>(request);

            mediaItem = await _mediaRepository.AddAsync(@mediaItem);

            return mediaItem.Id;
        }
    }
}
