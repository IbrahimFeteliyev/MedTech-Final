using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

var connectingString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MedtechDbContext>
    (options => options.UseSqlServer(connectingString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IntroductionServices>();
builder.Services.AddScoped<ServiceServices>();
builder.Services.AddScoped<QualitySystemServices>();
builder.Services.AddScoped<DiscountServices>();
builder.Services.AddScoped<AboutServices>();
builder.Services.AddScoped<PatientsSayServices>();
builder.Services.AddScoped<LastNewServices>();
builder.Services.AddScoped<MobileAppServices>();
builder.Services.AddScoped<CompanyServices>();
builder.Services.AddScoped<SendEmailServices>();
builder.Services.AddScoped<AppointmentServices>();
builder.Services.AddScoped<PrincipleServices>();
builder.Services.AddScoped<ProfessionalServices>(); 
    builder.Services.AddScoped<ContactServices>(); 










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

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
