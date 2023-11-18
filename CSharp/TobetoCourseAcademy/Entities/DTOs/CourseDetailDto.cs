using Core.Entities;

namespace Entities.DTOs
{
    public class CourseDetailDto:IDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }        
    }
}
