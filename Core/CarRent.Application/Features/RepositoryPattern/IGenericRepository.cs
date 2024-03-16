namespace CarRent.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();

        void Create(T entity);

        void Update(T entity);

        void Remove(T entity);

        T GetByID(int id);

        List<T> GetCommentsByBlogId(int id);

        public int GetCountCommendtByBlog(int id);
    }
}
