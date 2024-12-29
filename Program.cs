using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data;
using MusicLibrary.Data.Repo;
using MusicLibrary.Data.RepoInterface;

var builder = WebApplication.CreateBuilder(args);

// Auto Mapper Configurations
builder.Services.AddAutoMapper(cfg => 
cfg.AddProfile<MappingProfile>());

builder.Services.AddAutoMapper(cfg => cfg.AllowNullCollections = true);

builder.Services.AddAutoMapper(cfg => cfg.AddGlobalIgnore("Item"));

builder.Services.AddDbContext<MusicLibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// inject repos
builder.Services.AddScoped<ISongRepo, SongRepo>();
builder.Services.AddScoped<IGenreRepo, GenreRepo>();
builder.Services.AddScoped<IArtistRepo, ArtistRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Songs/Error");
//}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Songs}/{action=Index}/{id?}");

app.Run();
