using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Anket
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public bool See { get; set; }
        [BindRequired]
        public bool Like { get; set; }

        [BindRequired]
        public Guid UserId { get; set; }
    }
}