using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class InterestedUser
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public Guid UserId { get; set; }
    }
}