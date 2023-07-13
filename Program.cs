using Microsoft.EntityFrameworkCore;
using DatingSite.Data;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IBlank, BlankRepository>();
builder.Services.AddTransient<IChat, ChatRepository>();

var app = builder.Build();

app.UseMvc();
app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseStatusCodePagesWithReExecute("/Home/Index", "?code={0}");

app.UseMvc(routes => {
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();