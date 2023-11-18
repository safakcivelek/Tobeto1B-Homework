
namespace Business.Constants.Messages
{
    public static class InstructorMessages
    {
        public static string Added(string instructorName)
        {
            return $"{instructorName} instructor has been successfully added.";
        }
        public static string Updated(string instructorName)
        {
            return $"{instructorName} instructor has been successfully updated.";
        }
        public static string Deleted(string instructorName)
        {
            return $"{instructorName} instructor has been successfully deleted.";
        }
        public static string Listed(string instructorName, bool isPlural = false)
        {
            //Liste veya tek veri icin farkli donus mesajlari
            return isPlural
                ? "The instructors have been successfully listed."
                : $"{instructorName} instructor has been retrived successfully.";
        }
        public static string NotFound(string instructorName, bool isPlural = false)
        {
            return isPlural
                ? "No instructors found."
                : $"No instructor named {instructorName} found.";
        }
        public static string MaintenanceTime()
        {
            return "The system is under maintenance.";
        }
    }
}
