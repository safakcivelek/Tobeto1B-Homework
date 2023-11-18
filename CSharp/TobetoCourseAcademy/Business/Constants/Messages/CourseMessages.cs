
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
        public static string Listed(string courseName,bool isPlural=false)
        {
            //Liste veya tek veri icin farkli donus mesajlari
            return isPlural
                ? "The courses have been successfully listed."
                : $"{courseName} course has been retrived successfully."; 
        }
        public static string NotFound(string courseName,bool isPlural=false)
        {
            return isPlural
                ? "No courses found."
                : $"No course named {courseName} found.";
        }
        public static string MaintenanceTime()
        {
            return "The system is under maintenance.";
        }      
    }
}
