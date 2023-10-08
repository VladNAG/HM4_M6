using System.Data;
using HM4_M6.Data;
using HM4_M6.Interface;
using HM4_M6.Servises;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ITimer, TimerServise>();
builder.Services.AddSingleton<IDataCars, DataCars>();
builder.Services.AddTransient<ICarSevises, CarServises>();
builder.Services.AddSwaggerGen();
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
