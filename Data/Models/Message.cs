namespace DatingSite.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public DateTime Time { get; set; }
        public string Sender { get; set; } = null!;
        public bool Reading { get; set; }
    }
}