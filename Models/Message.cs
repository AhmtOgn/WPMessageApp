namespace WPMessageApp.Models
{
    public class Message
    {
        public int MessageId { get; set; } //Pk
        public string PhoneNumber { get; set; }
        public string MessageText { get; set; }
        public string? ImagePath { get; set; } // if image will be sent, takes path of image from wwwroot/uploads
        public string Status { get; set; } // pending - sent - failed
        public DateTime CreatedAt { get; set; } = DateTime.Now; // When message added to database 
        public DateTime SentAt { get; set; } // When message sent;
    }
}