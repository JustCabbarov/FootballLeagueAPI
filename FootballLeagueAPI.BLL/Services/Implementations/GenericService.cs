using AutoMapper;
using FootballLeague.BLL.Services.Interfaces;
using FootballLeague.DAL.Entities;
using FootballLeague.DAL.Repositories.Interfaces;

namespace FootballLeague.BLL.Services.Implementations
{
    public class GenericService<TVM, TCreateDTO, TEntity> : IGenericService<TVM, TCreateDTO, TEntity>
     where TVM : class
     where TCreateDTO : class
     where TEntity : BaseEntity, new()
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IMapper mapper, IGenericRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TVM> AddAsync(TCreateDTO createDto)
        {
            if (createDto == null)
            {
                throw new ArgumentNullException(nameof(createDto));
            }

            var entityToAdd = _mapper.Map<TEntity>(createDto);
            var result = await _repository.AddAsync(entityToAdd);
            return _mapper.Map<TVM>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<TVM>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return data == null ? null : _mapper.Map<IEnumerable<TVM>>(data);
        }

        public async Task<TVM> GetByIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            return data == null ? null : _mapper.Map<TVM>(data);
        }

        public async Task<bool> UpdateAsync(TVM viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            var entityToUpdate = _mapper.Map<TEntity>(viewModel);
            var result = await _repository.UpdateAsync(entityToUpdate);
            return result != null;
        }
    }

}
