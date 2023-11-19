using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;
        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _instructorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int instructorId)
        {
            var result = _instructorService.GetById(instructorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Instructor instructor)
        {
            var result = _instructorService.Add(instructor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Instructor instructor)
        {
            var result = _instructorService.Delete(instructor);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Instructor instructor)
        {
            var result = _instructorService.Update(instructor);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
