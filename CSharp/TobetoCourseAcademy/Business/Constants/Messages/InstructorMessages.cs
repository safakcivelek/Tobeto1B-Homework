
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
        public static string Listed()
        {
            return "The instructors have been successfully listed.";
        }
        public static string GetOne(string instructorName)
        {
            return $"{instructorName} instructor has been retrived successfully.";
        }
        public static string NotFound(bool isPlural = false)
        {
            return isPlural
                ? "No instructors found."
                : "No instructor found.";
        }
        public static string MaintenanceTime()
        {
            return "The system is under maintenance.";
        }

        //Bu metodlara geri dönüş tipi eklendikten sonra bu alandaki mesaj metodları silinecek!
        public static string Added()
        {
            return "The instructor has been successfully added.";
        }
        public static string Updated()
        {
            return "The instructor has been successfully updated.";
        }
        public static string Deleted()
        {
            return "The instructor has been successfully deleted.";
        }
    }
}
