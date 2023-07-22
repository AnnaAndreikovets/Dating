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
            return MockMessages.Chats?.FirstOrDefault(c => c.UserId.CompareTo(id) == 0);
        }

        public List<Chat>? Chats()
        {
            return Chats(MockPeople.User.Id)?.UserChats;
        }
    }
}