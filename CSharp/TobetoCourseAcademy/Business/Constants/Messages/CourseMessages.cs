
namespace Business.Constants.Messages
{
    public static class CourseMessages
    {
        public static string Added(string courseName)
        {
            return $"{courseName} course has been successfully added.";
        }       
        public static string Updated(string coursName)
        {
            return $"{coursName} course has been successfully updated.";
        }
        public static string Deleted(string coursName)
        {
            return $"{coursName} course has been successfully deleted.";
        }
        public static string Listed()
        {
            return "The courses have been successfully listed.";
        }
        public static string GetOne(string courseName)
        {
            return $"{courseName} course has been retrived successfully.";
        }

        public static string NotFound(bool isPlural = false)
        {
            return isPlural
                ? "No courses found."
                : "No course found.";
        }
        public static string MaintenanceTime()
        {
            return "The system is under maintenance.";
        }

        //Bu metodlara geri dönüş tipi eklendikten sonra bu alandaki mesaj metodları silinecek!
        public static string Added()
        {
            return "The course has been successfully added.";
        }
        public static string Updated()
        {
            return "The course has been successfully updated.";
        }
        public static string Deleted()
        {
            return "The course has been successfully deleted.";
        }
    }
}
