using Microsoft.AspNetCore.Mvc;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;
using DatingSite.Data;

namespace DatingSite.Controllers
{
    public class AnketsController : Controller
    {
        readonly IBlank blank;

        public AnketsController(IBlank blank)
        {
            this.blank = blank;
        }

        [Route("Ankets/List/{sex}")]
        public IActionResult Index(string sex)
        {
            //vm
            Blank result = blank.PersonForLooking(sex);
            
            return View(result);
        }

        [Route("Ankets/Skip/{guid}")]
        [Route("Ankets/Skip/{guid}/{like}")]
        public IActionResult Skip(Guid guid, bool like)
        {
            Blank? _blank = blank.Person(guid); //проверка, что айди верное
            
            if(like)
            {
                _blank.Like = true;
                //тут добавить пользователю чат, а так же закинуть его в Мок
            }

            _blank.See = true;
            //проверить, что есть непросмотренные люди, а иначе вернуть сообщение, что людей не найдено
            return RedirectToAction("Index", new {_blank.Sex});
        }
    }
}