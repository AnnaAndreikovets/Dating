using Microsoft.EntityFrameworkCore;
using DatingSite.Data;
using DatingSite.Data.Interfaces;
using DatingSite.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IBlank, BlankRepository>();

app.UseMvc();
app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
/*
app.UseStatusCodePagesWithReExecute("/Home/Index", "?code={0}");

app.UseMvc(routes => {
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
});

using(var scope = app.Services.CreateScope())
{
    ApplicationDBContent content = scope.ServiceProvider.GetRequiredService<ApplicationDBContent>()!;

    DBobjects.Initial(content);
}
*/

app.MapGet("/", () => "Hello World!");

app.Run();