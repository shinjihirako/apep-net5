using Apep.Application.Contracts.Persistence;
using Apep.Domain.Entities;
using Moq;
using System.Collections.Generic;

namespace MyHrApp.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<MediaItem>> GetMediaItemRepository()
        {
                      
            var mediaitems = new List<MediaItem>
            {
                new MediaItem
                {
                    Id = System.Guid.Empty,
                    Name = "Test Name 2",
                    Tag =  "Test Tag"
                },
                new MediaItem
                {
                    Id = System.Guid.Empty,
                    Name = "Test Name 2",
                    Tag =  "Test Tag"
                },
            };

            var mockMediaItemRepository = new Mock<IAsyncRepository<MediaItem>>();
            mockMediaItemRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(mediaitems);

            return mockMediaItemRepository;
        }
    }
}
