namespace StudyBattle.API.Services.Interfaces.Generic
{
    public interface IGenericService<TEntity, TCreateDTO, TUpdateDTO, TResponseDTO>
    {

        Task<TResponseDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<TResponseDTO>> GetAllAsync();
        Task<TResponseDTO> CreateAsync(TCreateDTO createDTO);
        Task<TResponseDTO> UpdateAsync(Guid id, TUpdateDTO updateDTO);
        Task<bool> DeleteAsync(Guid id);

    }
}
