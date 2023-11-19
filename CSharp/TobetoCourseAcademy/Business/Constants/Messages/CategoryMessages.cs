
namespace Business.Constants.Messages
{
    public static class CategoryMessages
    {
        public static string Added(string categoryName)
        {
            return $"{categoryName} category has been successfully added.";
        }
        public static string Updated(string categoryName)
        {
            return $"{categoryName} category has been successfully updated.";
        }
        public static string Deleted(string categoryName)
        {
            return $"{categoryName} category has been successfully deleted.";
        }
        public static string Listed()
        {
            return "The categories have been successfully listed.";
        }
        public static string GetOne(string categoryName)
        {
            return $"{categoryName} category has been retrived successfully.";
        }
        public static string NotFound(bool isPlural = false)
        {
            return isPlural
                ? "No categories found."
                : "No category found.";
        }
        public static string MaintenanceTime()
        {
            return "The system is under maintenance.";
        }

        //Bu metodlara geri dönüş tipi eklendikten sonra bu alandaki mesaj metodları silinecek!
        public static string Added()
        {
            return "The category has been successfully added.";
        }
        public static string Updated()
        {
            return "The category has been successfully updated.";
        }
        public static string Deleted()
        {
            return "The category has been successfully deleted.";
        }
    }
}
