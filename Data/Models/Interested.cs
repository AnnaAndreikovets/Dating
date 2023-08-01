using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Interested
    {
        [BindRequired]
        public Guid Id { get; set; }
        
        [BindRequired]
        public Guid UserId { get; set; }
        public List<InterestedUser>? Users { get; set; }
    }
}