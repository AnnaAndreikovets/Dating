namespace DatingSite.Data.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public Blank Blank { get; set; }
        public List<Message>? Messages { get; set; }
    }
}