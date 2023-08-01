using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Chat
    {
        [BindRequired]
        public Guid Id { get; set; }
        
        [BindRequired]
        public Guid BlankId { get; set; }
        [BindRequired]
        public Guid AnketId { get; set; }
        public List<Message>? Messages { get; set; }
    }
}