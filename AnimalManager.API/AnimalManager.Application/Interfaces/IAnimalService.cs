using AnimalManager.Application.Common;
using AnimalManager.Application.DTOs;

namespace AnimalManager.Application.Interfaces
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDto>> GetAllAsync();
        Task<AnimalDto> GetByIdAsync(Guid id);

        Task<Result<AnimalDto>> AddAsync(AnimalDto animalDto);
        Task<Result<AnimalDto>> UpdateAsync(Guid id, AnimalDto animalDto);
        Task DeleteAsync(Guid id);
    }
}