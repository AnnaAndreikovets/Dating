using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!; //добавить обработку, что там должно что-то присутствовать кроме пустых символов
        public DateTime Time { get; set; } //время отправки
    }
}