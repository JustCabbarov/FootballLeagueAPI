

using FootballLeague.DAL.Entities;

namespace FootballLeague.BLL.Services.Interfaces
{
    public interface IGenericService<TVM, TCreateDTO, TEntity>
     where TVM : class
     where TCreateDTO : class
     where TEntity : BaseEntity, new()
    {
        Task<TVM> AddAsync(TCreateDTO createDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TVM>> GetAllAsync();
        Task<TVM> GetByIdAsync(int id);
        Task<bool> UpdateAsync(TVM entity);
    }
}
