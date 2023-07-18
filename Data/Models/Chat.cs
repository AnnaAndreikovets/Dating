namespace DatingSite.Data.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public Blank Blank { get; set; } = null!;
        public List<Message>? Messages { get; set; }
    }
}