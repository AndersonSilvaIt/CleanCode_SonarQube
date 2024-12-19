using AnimalManager.Application.Common;
using AnimalManager.Application.DTOs;

namespace AnimalManager.Application.Interfaces
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDto>> GetAllAsync();
        Task<AnimalDto> GetByIdAsync(Guid id);

        Task<Result<AnimalDto>> AddAsync(AnimalDto dto);
        Task<Result<AnimalDto>> UpdateAsync(Guid id, AnimalDto dto);
        Task DeleteAsync(Guid id);
    }
}