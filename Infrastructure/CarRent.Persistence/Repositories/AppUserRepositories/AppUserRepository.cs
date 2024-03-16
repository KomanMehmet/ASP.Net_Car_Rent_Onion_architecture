using CarRent.Application.Interfaces.AppUserInterfaces;
using CarRent.Domain.Entities;
using CarRent.Persistence.Context;
using System.Linq.Expressions;

namespace CarRent.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarRentContext _context;

        public AppUserRepository(CarRentContext context)
        {
            _context = context;
        }

        public Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}
