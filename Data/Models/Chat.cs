namespace DatingSite.Data.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public List<Message>? Messages { get; set; }
    }
}