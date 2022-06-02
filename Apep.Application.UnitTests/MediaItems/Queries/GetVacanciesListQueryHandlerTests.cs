using Apep.Application.Contracts.Persistence;
using Apep.Application.Features.MediaItems.Queries.GetMediaItemsList;
using Apep.Application.Features.MediaItems.ViewModels;
using Apep.Application.Profiles;
using Apep.Domain.Entities;
using AutoMapper;
using Moq;
using MyHrApp.Application.UnitTests.Mocks;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MyHrApp.Application.UnitTests.Vacancies.Queries
{
    public class GetMediaItemListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<MediaItem>> _mockMediaItemRepository;

        public GetMediaItemListQueryHandlerTests()
        {
            _mockMediaItemRepository = RepositoryMocks.GetMediaItemRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }


        [Fact]
        public async Task GetMediaItemListTest()
        {
            var handler = new GetMediaItemListQueryHandler(_mapper, _mockMediaItemRepository.Object);

            var result = await handler.Handle(new GetMediaItemListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<MediaItemListViewModel>>();

            result.Count.ShouldBe(2);
        }
    }
}
