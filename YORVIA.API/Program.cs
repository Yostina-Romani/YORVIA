using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using YORVIA.Application;
using YORVIA.Infrastructure;
using YORVIA.Infrastructure.Identity;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dbcontext 
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience=true,
        ValidateIssuer=true,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,

        ValidIssuer = builder.Configuration["Authentication:Jwt:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Jwt:Audience"],
        IssuerSigningKey =new SymmetricSecurityKey( Encoding.UTF8.GetBytes(builder.Configuration["Authentication:Jwt:SecretKey"]!))

    };

    TimeSpan.FromMinutes(5);
});

builder.Services.AddAuthorization();

var app = builder.Build();


using (var scope = app.Services.CreateScope() )
{
    var rolemanager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await RoleSeeder.SeedAsync(rolemanager);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
