using DatingSite.Data.Models;

namespace DatingSite.Data.Mocks
{
    public class MockMessages
    {
        static List<Chat> chats = new List<Chat>()
        {
            new Chat()
            {
                Id = Guid.NewGuid(),
                BlankId = MockPeople.Blanks[1].Id,
                Messages = new List<Message>()
                {
                    new Message()
                    {
                        Id = 1,
                        Text = "First message"
                    },
                    new Message()
                    {
                        Id = 2,
                        Text = "flsd;jkfiosdjklfjklshj message"
                    },
                    new Message()
                    {
                        Id = 3,
                        Text = "bgrdklgjklergt ijfdljkf jdkfhj jhjdhjhjhf hbfhjfj message",
                        Time = DateTime.Now
                    }
                }
            }
        };
        
        static public List<Chat> Chats { get { return chats; } set { chats.AddRange(value); } }
    }
}