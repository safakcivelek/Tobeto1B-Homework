
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
        public static string Listed()
        {
            return "The coursesInstructors have been successfully listed.";
        }
        public static string GetOne(int courseInstructorId)
        {
            return $"Id={courseInstructorId} courseInstructor has been retrived successfully.";
        }
        public static string NotFound(bool isPlural = false)
        {
            return isPlural
                ? "No coursesInstructors found."
                : "No courseInstructor found.";
        }
        public static string MaintenanceTime()
        {
            return "The system is under maintenance.";
        }

        //Bu metodlara geri dönüş tipi eklendikten sonra bu alandaki mesaj metodları silinecek!
        public static string Added()
        {
            return "The courseInstructor has been successfully added.";
        }
        public static string Updated()
        {
            return "The courseInstructor has been successfully updated.";
        }
        public static string Deleted()
        {
            return "The courseInstructor has been successfully deleted.";
        }
    }
}
