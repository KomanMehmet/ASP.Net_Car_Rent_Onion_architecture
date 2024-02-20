using CarRent.Application.Interfaces.BlogInterfaces;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarRentContext _context;

        public BlogRepository(CarRentContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).ToList();

            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var value = _context.Blogs.Include(x => x.Author).Where(y => y.BlogID == id).ToList();

            return value;
        }

        public List<Blog> GetLastTreeBlogsWithAuthors()
        {
            var values = _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();

            return values;
        }
    }
}
