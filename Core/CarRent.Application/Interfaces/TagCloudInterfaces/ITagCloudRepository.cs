using CarRent.Domain.Entities;

namespace CarRent.Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRepository
    {
        List<TagCloud> GetTagCloudByBlogId(int id);
    }
}
