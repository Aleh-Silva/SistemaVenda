using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore.SqlServer;
using SistemaVenda.DAL;

var builder = WebApplication.CreateBuilder(args);

//----------------------------------------------------
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=.;Database=Estoque;Integrated Security=SSPI;TrustServerCertificate=True;MultipleActiveResultSets=True"));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();
//----------------------------------------------------

// Add services to the container.
builder.Services.AddControllersWithViews();



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

app.UseCookiePolicy(); //adicionei manualmente 

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
