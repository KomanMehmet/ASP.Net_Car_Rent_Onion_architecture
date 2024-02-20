using CarRent.Application.Interfaces.TagCloudInterfaces;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;

namespace CarRent.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarRentContext _context;

        public TagCloudRepository(CarRentContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudByBlogId(int id)
        {
            var values = _context.TagClouds.Where(x => x.BlogID == id).ToList();

            return values;
        }
    }
}
