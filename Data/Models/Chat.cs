using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Chat
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public Blank Blank { get; set; } = null!;
        public List<Message>? Messages { get; set; }
    }
}