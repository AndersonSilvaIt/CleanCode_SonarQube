using AnimalManager.Application.DTOs;
using AnimalManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService service)
        {
            _animalService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _animalService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _animalService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AnimalDto animalDto)
        {
            var result = await _animalService.AddAsync(animalDto);

            if (result.IsSuccess) return BadRequest(new { Errors = result.Errors });

            return Created("", result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AnimalDto animalDto)
        {
            if (id != animalDto.Id)
            {
                return BadRequest(new { Errors = new[] { "Animal ID mismatch" } });
            }

            var result = await _animalService.UpdateAsync(id, animalDto);

            if (result.IsSuccess) return BadRequest(new { Errors = result.Errors });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _animalService.DeleteAsync(id);
            return NoContent();
        }
    }
}