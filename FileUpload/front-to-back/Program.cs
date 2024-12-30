using front_to_back.DAL;
using front_to_back.Helpers;
using Microsoft.EntityFrameworkCore;

#region Builder

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFileService, FileService>();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

#endregion

#region App

var app = builder.Build();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{ controller = Home}/{ action = Index}/{ id ?}"    

//);
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
);

app.MapDefaultControllerRoute();

app.UseStaticFiles();
app.Run();

#endregion
