namespace ChatApplication.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
    }

    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
