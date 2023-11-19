using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Attribute
    public class CoursesController : ControllerBase
    {
        //Loosely coupled / gevşek bağlılık
        //naming convention
        //IoC Container -- Inversion of Control / Değişimin kontrolü
        //Hiçbir katman diğer katmanların somut classlarına bağlı olmamalıdır. Diğer katmanların soyut sınıfları üzerinden işlem yapılmalıdır.
        ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependency chain --
            var result = _courseService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);//200
            }
            return BadRequest(result.Message);//400
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int courseId)
        {
            var result = _courseService.GetById(courseId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Course course)
        {
            var result = _courseService.Add(course);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //Silme için Delete
        //Güncelleme için Update
        //Ama sektörde Silme ve Güncelleme için %99 oranla Post kullanılır.
        [HttpDelete("delete")]
        public IActionResult Delete(Course course)
        {
            var result = _courseService.Delete(course);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Course course)
        {
            var result = _courseService.Update(course);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
