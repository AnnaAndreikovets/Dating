using System.Linq;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Data.Repository
{
    public class ChatRepository : IChat
    {
        public Chat? Chat(Guid? id)
        {
            return Chats()?.FirstOrDefault(c => c.Id.CompareTo(id) == 0);
        }

        public Chats? Chats(Guid id)
        {
            return ListChats()?.FirstOrDefault(c => c.UserId.CompareTo(id) == 0);
        }

        public List<Chat>? Chats()
        {
            return Chats(MockPeople.User.Id)?.UserChats;
        }

        public void AddChats(Chats chats)
        {
            ListChats().Add(chats);
        }

        public void AddListChats(List<Chat> chats, Guid userId)
        {
            var chats_ = Chats(userId);

            if(chats_ is not null && chats_.UserChats is null)
            {
                chats_!.UserChats = chats;
            }
        }

        /*public void AddChat(Chat chat, Guid id)
        {
            Chats(id)?.UserChats?.Add(chat);
        }*/

        List<Chats> ListChats() => MockMessages.Chats;
    }
}