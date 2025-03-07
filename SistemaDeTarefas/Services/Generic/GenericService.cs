using AutoMapper;
using StudyBattle.api.Repostories.Interfaces.GenericRepository;
using StudyBattle.api.Services.Interfaces.Generic;

namespace StudyBattle.api.Services.Generic
{
    public class GenericService<TEntity, TCreateDTO, TUpdateDTO, TResponseDTO> : IGenericService
        <TEntity, TCreateDTO, TUpdateDTO, TResponseDTO> where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public async Task<TResponseDTO> CreateAsync(TCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                    throw new ArgumentNullException(nameof(createDTO));

                var entity = _mapper.Map<TEntity>(createDTO);
                var createdEntity = _repository.CreateAsync(entity);
                var responseDTO = _mapper.Map<TResponseDTO>(createdEntity);
                return responseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return false;
                _ = _repository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<TResponseDTO>> GetAllAsync()
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                var responseEntity = _mapper.Map<IEnumerable<TResponseDTO>>(entities);
                return responseEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<TResponseDTO> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id)?? throw new DirectoryNotFoundException("Entity not found");
                var response = _mapper.Map<TResponseDTO>(entity);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<TResponseDTO> UpdateAsync(Guid id, TUpdateDTO updateDTO)
        {
            try
            {
                if(updateDTO == null) throw new ArgumentException(nameof(updateDTO));

                var entitySearched = await _repository.GetByIdAsync(id) ?? throw new DirectoryNotFoundException("Entity not found");

                _mapper.Map(updateDTO, entitySearched);
                var updatedEntity = await _repository.UpdateAsync(id, entitySearched);

                var mappedEntity = _mapper.Map<TResponseDTO>(updatedEntity);
                return mappedEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
