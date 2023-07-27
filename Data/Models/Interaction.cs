using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Interaction
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public Guid UserId { get; set; }
        public List<Anket>? UsersAnkets { get; set; }
    }
}