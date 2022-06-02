using Apep.Application.Features.MediaItems.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Apep.Application.Features.MediaItems.Queries.GetMediaItemsList
{
    public class GetMediaItemListQuery : IRequest<List<MediaItemListViewModel>>
    {
    }
}
