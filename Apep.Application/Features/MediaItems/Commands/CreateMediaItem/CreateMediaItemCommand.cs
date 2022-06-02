using MediatR;
using System;

namespace Apep.Application.Features.MediaItems.Commands.CreateMediaItem
{
    public class CreateMediaItemCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
