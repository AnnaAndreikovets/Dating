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
                Blank = MockBlanks.Blanks.First()
            },
            new Chat()
            {
                Id = Guid.NewGuid(),
                Blank = MockBlanks.Blanks.Last(),
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
            },
            new Chat()
            {
                Id = Guid.NewGuid(),
                Blank = MockBlanks.Blanks.Last(),
            },
            new Chat()
            {
                Id = Guid.NewGuid(),
                Blank = MockBlanks.Blanks.Last(),
                Messages = new List<Message>()
                {
                    new Message()
                    {
                        Id = 3,
                        Text = "third",
                        Time = new DateTime(2017, 7, 20)
                    }
                }
            }
        }; //чисито для теста заполнила
        
        static public List<Chat> Chats { get { return chats; } set { chats.AddRange(value); } }
    }
}