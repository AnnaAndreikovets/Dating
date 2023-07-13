namespace DatingSite.Data.Models
{
    public class Blank
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public byte Years { get; set; }
        public string Photo { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public string PreferSex { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Guid? ChatId { get; set; }

        public bool See { get; set; } //типо уже видели этого человека
        public bool Like { get; set; } //контакт есть/ нет
    }
}