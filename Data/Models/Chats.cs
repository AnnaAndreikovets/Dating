using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Chats
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public Guid UserId { get; set; }
        public List<Chat>? UserChats { get; set; }
    }
}