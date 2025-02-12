using BankManagement.Core.Interfaces;
using BankManagement.Core.Services;
using BankManagement.Core.Services;
using BankManagement.Infrastructure.Data;
using BankManagement.Core.Interfaces;


//using BankManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Umbraco.Core.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ✅ 1️⃣ Add Database Context (EF Core)
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ 2️⃣ Add Controllers
builder.Services.AddControllers();

builder.Services.AddScoped<ITransactionService, TransactionService>();


// ✅ 3️⃣ Add Swagger (API Documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ 4️⃣ Configure Dependency Injection (Services & Repositories)
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// ✅ 5️⃣ Enable CORS (Allow Frontend Requests)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// ✅ 6️⃣ Enable Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ 7️⃣ Enable CORS Middleware
app.UseCors("AllowAll");

// ✅ 8️⃣ Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// ✅ 9️⃣ Enable Authorization & Authentication (If needed)
app.UseAuthorization();

// ✅ 1️⃣0️⃣ Map API Controllers
app.MapControllers();

// ✅ 1️⃣1️⃣ Add Default Route (Fixes 404 at "/")
app.MapGet("/", () => "Welcome to Bank Management API!");

app.Run();
