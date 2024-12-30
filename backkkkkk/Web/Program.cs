using Core.Entities;
using Core.Utilities.FileService;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Web.Services.Abstract;
using Web.Services.Concrete;
using AdminServiceAbstract= Web.Areas.Admin.Services.Abstract;
using  AdminServiceConcrete=Web.Areas.Admin.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
#region Configuration
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsAssembly("DataAccess")));
#endregion
#region UserIdentification
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

})
    .AddEntityFrameworkStores<AppDbContext>();
#endregion
#region Repositories
builder.Services.AddScoped<IBespokeAnimationRepository, BespokeAnimationRepository>();
builder.Services.AddScoped<IBespokeInformRepository, BespokeInformRepository>();
builder.Services.AddScoped<IHomeAnimationRepository, HomeAnimationRepository>();
builder.Services.AddScoped<IFineJewellerAnimationRepository, FineJewellerAnimationRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();    
builder.Services.AddScoped<IFJProductRepository, FJProductRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketProductRepository, BasketProductRepository>();
builder.Services.AddScoped<IHomeSliderRepository, HomeSliderRepository>();  
builder.Services.AddScoped<IWeddingMainRepository, IWeddingMainRepository>();   
builder.Services.AddScoped<IHighJewellerMainRepository, HighJewellerMainRepository>();  
#endregion
#region Services
builder.Services.AddScoped<IAccountService, AccountService>();  
builder.Services.AddScoped<AdminServiceAbstract.IAccountService, AdminServiceConcrete.AccountService>();
builder.Services.AddScoped<IBespokeService, BespokeService>();
builder.Services.AddScoped<AdminServiceAbstract.IBespokeInformService, AdminServiceConcrete.BespokeInformService>();
builder.Services.AddScoped<AdminServiceAbstract.IBespokeAnimationService, AdminServiceConcrete.BespokeAnimationService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<AdminServiceAbstract.IHomeAnimationService, AdminServiceConcrete.HomeAnimationService>();
builder.Services.AddScoped<IFineJewellerService, FineJewellerService>();
builder.Services.AddScoped<AdminServiceAbstract.IFineJewellerAnimationService, AdminServiceConcrete.FineJewellerAnimationService>();
builder.Services.AddScoped<AdminServiceAbstract.IProductService, AdminServiceConcrete.ProductService>();
builder.Services.AddScoped<AdminServiceAbstract.IFJProductService, AdminServiceConcrete.FJProductService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<AdminServiceAbstract.IHomeSliderService, AdminServiceConcrete.HomeSliderService>();
builder.Services.AddScoped<AdminServiceAbstract.IWeddingMainService, AdminServiceConcrete.WeddingMainService>();
builder.Services.AddScoped<AdminServiceAbstract.IHighJewellerMainService, AdminServiceConcrete.HighJewellerMainService>();   
builder.Services.AddScoped<IWeddingService, WeddingService>();  
builder.Services.AddScoped<IHighJewellerService, HighJewellerService>();    
builder.Services.AddSingleton<IFileService, FileService>();
#endregion
#region BuildApp
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
#endregion
#region Route
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=account}/{action=login}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion
#region scopefactory
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using (var scope = scopeFactory.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
    await DbInitializer.SeedAsync(userManager, roleManager);
}
#endregion
app.Run();
