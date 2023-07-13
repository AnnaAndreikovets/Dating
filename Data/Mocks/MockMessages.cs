using DatingSite.Data.Models;

namespace DatingSite.Data.Mocks
{
    public class MockMessages
    {
        static List<Chat> chats = new List<Chat>();
        //сюда добавить чат с каким-нибудь человечком
        static public List<Chat> Chats { get { return chats; } set { chats.AddRange(value); } }
    }
}