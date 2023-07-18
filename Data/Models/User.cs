namespace DatingSite.Data.Models
{
    public class User
    {
        //так это просто как дополнение. Разве это можно назвать моделью без айди
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}