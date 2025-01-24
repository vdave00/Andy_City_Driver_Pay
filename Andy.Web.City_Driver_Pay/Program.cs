using Andy.Web.City_Driver_Pay.Service;
using Andy.Web.City_Driver_Pay.Service.IService;
using Andy.Web.City_Driver_Pay.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IDriverService,DriverService>();
SD.DriverAPIBase = builder.Configuration["ServiceUrls:DriverAPI"];
SD.PayRateAPI = builder.Configuration["ServiceUrls:PayRateAPI"];

builder.Services.AddScoped<IBaseService,BasService>();
builder.Services.AddScoped<IDriverService,DriverService>();
builder.Services.AddScoped<IPayPeriodService,PayPeriodService>();
builder.Services.AddScoped<IDriverPayRateRule,DriverPayRateRule>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Secure the cookie
    options.Cookie.IsEssential = true; // Necessary for GDPR compliance
});

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
