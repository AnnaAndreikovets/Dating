using DatingSite.Data.Models;

namespace DatingSite.Data.Mocks
{
    public static class MockMessages
    {
        static List<Chats> chats = new List<Chats>();
        
        static public List<Chats> Chats { get { return chats; } set { chats.AddRange(value); } }
    }
}