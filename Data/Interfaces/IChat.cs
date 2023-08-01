using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IChat
    {
        public Chat? Chat(Guid? id);
        public Chats? Chats(Guid id);
        public List<Chat>? Chats();
        public Task DeleteChat(Guid userId, Guid blankId);
        public Task AddChatAndLike(Guid id1, Guid id2);
    }
}