namespace DatingSite.Data.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Name { get; set;} = null!;
        public short UreadMessagesCount { get; set; }
        public string LastMessage { get; set; } = "The user reciprocated! Start a chat.";
        public List<Message>? Messages { get; set; }
    }
}