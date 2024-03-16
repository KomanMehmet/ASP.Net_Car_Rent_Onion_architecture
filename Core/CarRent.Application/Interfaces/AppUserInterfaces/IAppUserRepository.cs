using CarRent.Domain.Entities;
using System.Linq.Expressions;

namespace CarRent.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filterExpression);
    }
}
