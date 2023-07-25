using System.Linq;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data.Mocks;

namespace DatingSite.Data.Repository
{
    public class ChatRepository : IChat
    {
        public Chat? Chat(Guid? id) => Chats()?.FirstOrDefault(c => c.BlankId.CompareTo(id) == 0);

        public Chats? Chats(Guid id) => ListChats()?.FirstOrDefault(c => c.UserId.CompareTo(id) == 0);

        public List<Chat>? Chats() => Chats(MockPeople.User.Id)?.UserChats;

        public void AddChats(Chats chats) => ListChats().Add(chats);

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
        public void DeleteChat(Guid userId, Guid blankId)
        {
            var userChats = Chats(userId)?.UserChats;
            
            if(userChats is not null)
            {
                Chat? chat = userChats?.FirstOrDefault(c => c.BlankId.CompareTo(blankId) == 0);

                if(chat is not null)
                {
                    userChats!.Remove(chat);
                    
                    return;
                }
            }

            throw new ArgumentNullException();
        }
    }
}