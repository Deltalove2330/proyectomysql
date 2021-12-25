using proyectomysql.AccesoDatos.Data;

using Microsoft.EntityFrameworkCore;  
  



var builder = WebApplication.CreateBuilder(args);


 
builder.Services.AddDbContext<Dbcontex>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
//AGREGAR RAZOR COMPILATION
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Inventario}/{controller=Home}/{action=Index}/{id?}");

app.Run();
