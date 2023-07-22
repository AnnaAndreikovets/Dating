using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IChat
    {
        public Chat? Chat(Guid? id);
        public Chats? Chats(Guid id);
        public List<Chat>? Chats();
    }
}