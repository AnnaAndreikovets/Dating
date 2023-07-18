using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Like
    {
        [BindRequired]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<Guid>? UsersId { get; set; }
    }
}