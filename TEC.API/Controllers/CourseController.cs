using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEC.Domain.Dtos;
using TEC.Domain.Models;
using TEC.Repository.Interface;

namespace TEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public CourseController(
            ILogger<CourseController> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Courses = _mapper.Map<IEnumerable<CourseDto>>(_unitOfWork.CourseRepository.GetAll());

                return Ok(Courses);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get Course by Course id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            try
            {
                var Course = _unitOfWork.CourseRepository.Get(id);

                if (Course is null)
                {
                    return NotFound();
                }

                var CourseResult = _mapper.Map<CourseDto>(Course);

                return Ok(CourseResult);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Create Course 
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseCreateDto Course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var CourseEntity = _mapper.Map<Course>(Course);
                    _unitOfWork.CourseRepository.Add(CourseEntity);
                    _unitOfWork.Complete();

                    var createdCourse = _mapper.Map<CourseDto>(CourseEntity);

                    return CreatedAtAction("GetCourse", new { CourseEntity.Id }, createdCourse);
                }

                return BadRequest("Invalid Course Data.");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update Course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Course"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseUpdateDto Course)
        {
            try
            {
                var CourseEntity = _unitOfWork.CourseRepository.Get(id);

                if (CourseEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(Course, CourseEntity);

                _unitOfWork.CourseRepository.Update(CourseEntity);
                _unitOfWork.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(500);

            }
        }

        /// <summary>
        /// Delete Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var Course = _unitOfWork.CourseRepository.Get(id);

                if (Course == null)
                {
                    return NotFound();
                }

                _unitOfWork.CourseRepository.Remove(Course);
                _unitOfWork.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return StatusCode(500);
            }

        }
    }
}
