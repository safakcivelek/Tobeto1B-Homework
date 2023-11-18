
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
        public static string Listed(string categoryName, bool isPlural = false)
        {
            //Liste veya tek veri icin farkli donus mesajlari
            return isPlural
                ? "The categories have been successfully listed."
                : $"{categoryName} category has been retrived successfully.";
        }
        public static string NotFound(string categoryName, bool isPlural = false)
        {
            return isPlural
                ? "No categories found."
                : $"No category named {categoryName} found.";
        }
        public static string MaintenanceTime()
        {
            return "The system is under maintenance.";
        }
    }
}
