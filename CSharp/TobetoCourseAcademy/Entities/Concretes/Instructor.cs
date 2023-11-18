using Core.Entities;

namespace Entities.Concretes
{
    public class Instructor:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public List<CourseInstructor> CourseInstructors { get; set; }
    }
}
