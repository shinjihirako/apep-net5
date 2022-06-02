using Apep.Application.Contracts.Persistence;
using FluentValidation;
using System;

namespace Apep.Application.Features.MediaItems.Commands.CreateMediaItem
{
    public class CreateMediaItemCommandValidator : AbstractValidator<CreateMediaItemCommand>
    {
        private readonly IMediaItemRepository _mediaItemRepository;

        public CreateMediaItemCommandValidator(IMediaItemRepository mediaItemRepository)
        {
            _mediaItemRepository = mediaItemRepository;

            RuleFor(p => p.Name)
                      .NotEmpty().WithMessage("{PropertyName} is required.")
                      .NotNull()
                      .MaximumLength(50).WithMessage("{PropertyName} must not exceed 15 characters.");

            RuleFor(p => p.CreatedDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

        }
    }
}
