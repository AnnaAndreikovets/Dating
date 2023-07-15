using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IChat
    {
        public Chat? Chat(Guid? id);
        public void AddChat(Chat chat);
        public IEnumerable<Chat>? Chats();
    }
}