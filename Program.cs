using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Repository;
using DatingSite.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IPeople, PeopleRepository>();
builder.Services.AddTransient<IChat, ChatRepository>();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(AuthTokenFilter));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie("Cookies", options => {
    options.LoginPath = "/Authorize/LogIn";
    options.AccessDeniedPath = "/";
    options.LogoutPath = "/Authorize/LogOut";
});
builder.Services.AddAuthorization();

builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseExceptionHandler("/");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

using(var scope = app.Services.CreateScope())
{
    ApplicationDBContext content = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>()!;

    DBobjects.Initial(content);
}

//app.UseStatusCodePagesWithReExecute("/Home/Index", "?code={0}");

app.UseMvc(routes => {
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();