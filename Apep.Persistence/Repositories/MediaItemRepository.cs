using Apep.Application.Contracts.Persistence;
using Apep.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Apep.Persistence.Repositories
{
    public class MediaItemRepository : BaseRepository<MediaItem>, IMediaItemRepository
    {
        public MediaItemRepository(ApepDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsMediaItemUnique(string name)
        {
            var matches = _dbContext.mediaItems.Any(e => e.Name.Equals(name));
            return Task.FromResult(matches);
        }

    }
}
