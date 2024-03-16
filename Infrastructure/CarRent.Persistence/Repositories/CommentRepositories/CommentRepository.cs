﻿using CarRent.Application.Features.RepositoryPattern;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;

namespace CarRent.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarRentContext _context;

        public CommentRepository(CarRentContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x => new Comment
            {
                Name = x.Name,
                Content = x.Content,
                CreatedDate = DateTime.Now,
                CommentID = x.CommentID,
                BlogID = x.BlogID,
            }).ToList();
        }

        public Comment GetByID(int id)
        {
            return _context.Comments.Find(id);
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x => x.BlogID == id).ToList();
        }

        public void Remove(Comment entity)
        {
            var value = _context.Comments.Find(entity.CommentID);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }

        public int GetCountCommendtByBlog(int id)
        {
            return _context.Comments.Where(x => x.BlogID == id).Count();
        }
    }
}
