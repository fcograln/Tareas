using Microsoft.EntityFrameworkCore;
using TaskMVC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Configurar para SQLServer
 //builder.Services.AddDbContext<TareaDbContext>(options => 
   //      options.UseSqlServer(builder.Configuration.GetConnectionString("sqlserver")));

//Configurar para SQLite
builder.Services.AddDbContext<TareaDbContext>(options => 
        options.UseSqlite(builder.Configuration.GetConnectionString("sqlite"))); 

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tarea}/{action=Index}/{id?}");

app.Run();
