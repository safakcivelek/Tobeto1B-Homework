using Core.Entities;
using Entities.Concretes;

namespace Entities.DTOs
{
    public class CourseDetailDto:IDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public List<InstructorDetailDto> Instructors { get; set; }       
    }
    public class InstructorDetailDto:IDto
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        CourseDetailDto CourseDetailDto { get; set; }
    }
}
