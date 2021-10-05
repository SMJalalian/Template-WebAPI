namespace MyProject.Services.DTOs.Messaging
{
    public class EmailDto
    {
        public string SenderName { get; set; }
        public string RecieverEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = true;
    }
}
