using Microsoft.AspNetCore.Mvc.Filters;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Models;

namespace DatingSite.Data
{
    public class AuthTokenFilter : IActionFilter
    {
        readonly IPeople people;

        public AuthTokenFilter(IPeople people)
        {
            this.people = people;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var cookies = context.HttpContext.Request.Cookies;

            if (ApplicationDBContext.User is null && cookies.TryGetValue("password", out string? password) && cookies.TryGetValue("email", out string? email))
            {
                if (password is not null && email is not null)
                {    
                    User? user = people.User(email, password);;

                    if(user is not null)
                    {
                        ApplicationDBContext.User = user;
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context){}
    }
}