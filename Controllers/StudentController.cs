using Microsoft.AspNetCore.Mvc;
using AlrightAPI.Interface;
using AlrightAPI.NewFolder;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlrightAPI.Models;
using AlrightAPI.Services;

namespace AlrightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository; // Automatically injected! dependency Injection 
            _mapper = mapper;
          
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(studentDtos);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Invalid student data.");
            }

            var studentEntity = _mapper.Map<Student>(studentDto);
            var addedStudent = await _studentRepository.AddAsync(studentEntity);
            var addedStudentDto = _mapper.Map<StudentDto>(addedStudent);

            return Ok(addedStudentDto); 
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            _mapper.Map(studentDto, existingStudent);
            await _studentRepository.UpdateAsync(existingStudent);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with ID: {id} not found.");
            }

            await _studentRepository.DeleteAsync(id);
            return NoContent();
        }
    }

}
