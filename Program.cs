using DatingSite.Data.Interfaces;
using DatingSite.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IPeople, PeopleRepository>();
builder.Services.AddTransient<IChat, ChatRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie("Cookies", options => {
    options.LoginPath = "/Authorize/LogIn";
    //options.AccessDeniedPath = "/Authorize/LogIn";
    options.LogoutPath = "/Authorize/LogOut";
});
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseMvc();
app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

//app.UseStatusCodePagesWithReExecute("/Home/Index", "?code={0}");

app.UseMvc(routes => {
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();