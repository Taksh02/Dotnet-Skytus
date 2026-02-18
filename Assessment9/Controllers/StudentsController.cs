using Microsoft.AspNetCore.Mvc;
using Assessment9.Repositories;
using Assessment9.DTOs;
using Assessment9.Models;
using AutoMapper;

namespace Assessment9.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetAll()
        {
            var students = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDto>> GetById(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            return Ok(_mapper.Map<StudentReadDto>(student));
        }

        [HttpPost]
        public async Task<ActionResult<StudentReadDto>> Create(StudentCreateDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            await _repository.AddAsync(student);
            await _repository.SaveChangesAsync();

            var readDto = _mapper.Map<StudentReadDto>(student);

            return CreatedAtAction(nameof(GetById),
                new { id = student.Id, version = "1.0" },
                readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentUpdateDto dto)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            _mapper.Map(dto, student);
            _repository.Update(student);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            _repository.Delete(student);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
