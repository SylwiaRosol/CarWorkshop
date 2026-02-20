namespace CarWorkshop.Models
{
    public class Notification
    {
        public string Message { get; set; }
        public string Type { get; set; } // "success", "error", "info", etc.
        public Notification(string type, string message)
        {
            Message = message;
            Type = type;
        }
    }
}
