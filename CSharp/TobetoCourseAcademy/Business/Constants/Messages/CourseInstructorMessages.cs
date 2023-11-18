
namespace Business.Constants.Messages
{
    public static class CourseInstructorMessages
    {
        public static string Added(string courseInstructorName)
        {
            return $"{courseInstructorName} courseInstructor has been successfully added.";
        }
        public static string Updated(string courseInstructorName)
        {
            return $"{courseInstructorName} courseInstructor has been successfully updated.";
        }
        public static string Deleted(string courseInstructorName)
        {
            return $"{courseInstructorName} courseInstructor has been successfully deleted.";
        }
        public static string Listed(string courseInstructorName, bool isPlural = false)
        {
            //Liste veya tek veri icin farkli donus mesajlari
            return isPlural
                ? "The coursesInstructors have been successfully listed."
                : $"{courseInstructorName} courseInstructor has been retrived successfully.";
        }
        public static string NotFound(string courseInstructorName, bool isPlural = false)
        {
            return isPlural
                ? "No coursesInstructors found."
                : $"No courseInstructor named {courseInstructorName} found.";
        }
        public static string MaintenanceTime()
        {
            return "The system is under maintenance.";
        }
    }
}
