using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseInstructorsController : ControllerBase
    {
        ICourseInstructorService _service;
        public CourseInstructorsController(ICourseInstructorService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int courseInstructorId)
        {
            var result = _service.GetById(courseInstructorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpPost("add")]
        public IActionResult Add(CourseInstructor courseInstructor)
        {
            var result = _service.Add(courseInstructor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(CourseInstructor courseInstructor)
        {
            var result = _service.Delete(courseInstructor);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpPut("update")]
        public IActionResult Update(CourseInstructor courseInstructor)
        {
            var result = _service.Update(courseInstructor);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
