using DatingSite.Data.Models;

namespace DatingSite.Data.Interfaces
{
    public interface IChat
    {
        public Chat? Chat(Guid? id);
        public Chats? Chats(Guid id);
        public List<Chat>? Chats();
        public void AddChats(Chats chats);
        public void AddListChats(List<Chat> chats, Guid userId);
        //public void AddChat(Chat chat, Guid id);
        public void DeleteChat(Guid userId, Guid blankId);
    }
}