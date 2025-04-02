using AlrightAPI.Models.Dto_s;
using AlrightAPI.Models.Entities;
using AlrightAPI.Repository;
using AlrightAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlrightAPI.Models.Dto;
using AlrightAPI.Interface;


namespace AlrightAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository; 
        private readonly JwtService _jwtService;

        public TeacherController(ITeacherRepository teacherRepository, JwtService jwtService)
        {
            _teacherRepository = teacherRepository;
            _jwtService = jwtService;
        }

        // REGISTER TEACHER
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] TeacherDto teacherDto)
        {
            if (teacherDto == null) return BadRequest("Invalid data");

            var teacher = new Teacher
            {
                TeacherId = Guid.NewGuid(),
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(teacherDto.Password),
                NationalIDNumber = teacherDto.NationalIDNumber,
                MaritalStatus = teacherDto.MaritalStatus,
                Gender = teacherDto.Gender
            };

            await _teacherRepository.AddAsync(teacher);
            return Ok("Teacher registered successfully");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var teacher = await _teacherRepository.GetByNationalIDAsync(loginDto.NationalIDNumber);

            if (teacher == null)
            {
                return Unauthorized("Invalid credentials - No user found with this National ID");
            }

            Console.WriteLine($"User Found: {teacher.NationalIDNumber}");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, teacher.Password))
            {
                return Unauthorized("Invalid credentials - Password mismatch");
            }

            var token = _jwtService.GenerateToken(teacher.Role, teacher.TeacherId, teacher.NationalIDNumber);
            return Ok(new { Token = token });
        }


        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllTeachers()
        {
            return Ok(await _teacherRepository.GetAllAsync());
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }
            return Ok(teacher);
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDto teacherDto)
        {
            var existingTeacher = await _teacherRepository.GetByIdAsync(id);
            if (existingTeacher == null)
            {
                return NotFound("Teacher not found");
            }


            existingTeacher.FirstName = teacherDto.FirstName;
            existingTeacher.LastName = teacherDto.LastName;
            existingTeacher.NationalIDNumber = teacherDto.NationalIDNumber;
            existingTeacher.MaritalStatus = teacherDto.MaritalStatus;
            existingTeacher.Gender = teacherDto.Gender;

            await _teacherRepository.UpdateAsync(existingTeacher);
            return Ok("Teacher updated successfully");
        }

        [Authorize(Roles = "Teacher")] 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }

            await _teacherRepository.DeleteAsync(id);
            return Ok("Teacher deleted successfully");
        }
    }
}
