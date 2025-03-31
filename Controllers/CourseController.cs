using Microsoft.AspNetCore.Mvc;
using AlrightAPI.Interface;
using AlrightAPI.NewFolder;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlrightAPI.Models;

namespace AlrightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository; // Dependency Injection 
            _mapper = mapper;
        }

        // GET: api/course
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseRepository.GetAllAsync();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(courseDtos);
        }

        // GET: api/course/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }

            var courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }

        // POST: api/course (Adding a New Course)
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseDto courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest("Invalid course data.");
            }

            var courseEntity = _mapper.Map<Course>(courseDto);
            var addedCourse = await _courseRepository.AddAsync(courseEntity);
            var addedCourseDto = _mapper.Map<CourseDto>(addedCourse);

            return Ok(addedCourseDto); // No need for CreatedAtAction since there's no Id in DTO
        }

        // PUT: api/course/{id} (Updating an Existing Course)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseDto courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var existingCourse = await _courseRepository.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }

            _mapper.Map(courseDto, existingCourse);
            await _courseRepository.UpdateAsync(existingCourse);

            return NoContent();
        }

        // DELETE: api/course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCourse = await _courseRepository.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound($"Course with ID {id} not found.");
            }

            await _courseRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
