using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BankManagmentAPI.Data;  // Ensure the correct namespace for DataContext

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ ✅ Configure Database Connection
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2️⃣ ✅ Configure Identity (Authentication & User Management)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// 3️⃣ ✅ Add Authentication & Authorization Middleware
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// 4️⃣ ✅ Add Controllers (MVC API)
builder.Services.AddControllers();

// 5️⃣ ✅ Configure Swagger for API Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank Management API", Version = "v1" });
});

var app = builder.Build();

// 6️⃣ ✅ Enable Swagger (for testing API endpoints)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 7️⃣ ✅ Enable Security Middleware
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// 8️⃣ ✅ Map API Controllers
app.MapControllers();

app.Run();
