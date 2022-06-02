using Apep.Application.Features.MediaItems.ViewModels;
using MediatR;
using System;

namespace Apep.Application.Features.MediaItems.Queries.GetMediaItemDetail
{
    public class GetMediaItemDetailQuery: IRequest<MediaItemDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
