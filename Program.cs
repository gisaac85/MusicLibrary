using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data;
using MusicLibrary.Data.Repo;
using MusicLibrary.Data.RepoInterface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MusicLibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// inject the ISongRepo interface and the SongRepo class
builder.Services.AddScoped<ISongRepo, SongRepo>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Songs}/{action=Index}/{id?}");

app.Run();
