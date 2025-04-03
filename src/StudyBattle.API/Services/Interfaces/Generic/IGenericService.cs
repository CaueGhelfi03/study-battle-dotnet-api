namespace StudyBattle.API.Services.Interfaces.Generic
{
    public interface IGenericService<TKey,TEntity, TCreateDTO, TUpdateDTO, TResponseDTO>
    {

        Task<TResponseDTO> GetByIdAsync(TKey id);
        Task<IEnumerable<TResponseDTO>> GetAllAsync();
        Task<TResponseDTO> CreateAsync(TCreateDTO createDTO);
        Task<TResponseDTO> UpdateAsync(TKey id, TUpdateDTO updateDTO);
        Task<bool> DeleteAsync(TKey id);

    }
}
