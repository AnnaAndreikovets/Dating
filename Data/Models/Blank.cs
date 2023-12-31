using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Data.Models
{
    public class Blank
    {
        [BindRequired]
        public Guid Id { get; set; }
        [BindRequired]
        public string FirstName { get; set; } = null!;
        [BindRequired]
        public string SecondName { get; set; } = null!;
        [BindRequired]
        public byte Age { get; set; }
        [BindRequired]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; } = null!;
        [BindRequired]
        public string Description { get; set; } = null!;
        [BindRequired]
        public string Sex { get; set; } = null!;
        [BindRequired]
        public string PreferSex { get; set; } = null!;
    }
}