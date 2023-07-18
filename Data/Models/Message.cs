using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Message
    {
        [BindRequired]
        public int Id { get; set; }
        [BindRequired]
        public string Text { get; set; } = null!;
        [BindRequired]
        public DateTime Time { get; set; }
        [BindRequired]
        public string Sender { get; set; } = null!;
        [BindRequired]
        public bool Reading { get; set; }
    }
}