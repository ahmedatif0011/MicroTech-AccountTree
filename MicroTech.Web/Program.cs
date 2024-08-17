
using MicroTech.Web.Settings;

var builder = WebApplication.CreateBuilder(args);
AppDI.Services(builder);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
AppBuilder.Builder(app);



app.Run();
