
using CarRent.Domain.Entities;

namespace CarRent.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public List<Blog> GetLastTreeBlogsWithAuthors();

        public List<Blog> GetAllBlogsWithAuthors();

        public List<Blog> GetBlogByAuthorId(int id);
    }
}
