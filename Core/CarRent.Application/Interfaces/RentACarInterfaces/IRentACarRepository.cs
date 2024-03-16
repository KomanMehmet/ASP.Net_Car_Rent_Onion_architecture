using CarRent.Domain.Entities;
using System.Linq.Expressions;

namespace CarRent.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
        Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter);//Bool geriye dönecek olan durumu belirleyecek. Filter da göndereceğimiz şart.
    }
}
