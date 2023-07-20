using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class User
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public Guid BlankId { get; set; }
        
        [BindRequired]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [BindRequired]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public Guid? ChatId { get; set; }
    }
}