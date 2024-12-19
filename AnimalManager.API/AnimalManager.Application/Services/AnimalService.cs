using AnimalManager.Application.Common;
using AnimalManager.Application.DTOs;
using AnimalManager.Application.Interfaces;
using AnimalManager.Domain.Entities;
using AnimalManager.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

namespace AnimalManager.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<AnimalDto> _animalValidator;
        public AnimalService(IRepository<Animal> repository, IMapper mapper, IValidator<AnimalDto> animalValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _animalValidator = animalValidator;
        }

        public async Task<IEnumerable<AnimalDto>> GetAllAsync()
        {
            var animals = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AnimalDto>>(animals);
        }

        public async Task<AnimalDto> GetByIdAsync(Guid id)
        {
            var animal = await _repository.GetByIdAsync(id);
            return _mapper.Map<AnimalDto>(animal);
        }


        public async Task<Result<AnimalDto>> AddAsync(AnimalDto animalDto)
        {
            ValidationResult validationResult = _animalValidator.Validate(animalDto);

            if (!validationResult.IsValid)
            {
                return Result<AnimalDto>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            var animal = _mapper.Map<Animal>(animalDto);

            await _repository.AddAsync(animal);

            return Result<AnimalDto>.Success(_mapper.Map<AnimalDto>(animal));
        }

        public async Task<Result<AnimalDto>> UpdateAsync(Guid id, AnimalDto animalDto)
        {
            var animal = await _repository.GetByIdAsync(id);
            if (animal == null)
            {
                return Result<AnimalDto>.Fail("Animal not found");
            }

            ValidationResult validationResult = _animalValidator.Validate(animalDto);

            if (!validationResult.IsValid)
            {
                return Result<AnimalDto>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            animal.Update(animalDto.Name, animalDto.Species, animalDto.Age);
            await _repository.UpdateAsync(animal);

            return Result<AnimalDto>.Success(_mapper.Map<AnimalDto>(animal));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);

        }
    }
}