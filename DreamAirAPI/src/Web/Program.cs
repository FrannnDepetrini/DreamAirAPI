




using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static Infrastructure.Services.AutenticationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var connection = new SqliteConnection("data source = DB-Flights.db");
string connectionString = builder.Configuration["ConnectionStrings:DreamAirDBConnectionString"];
var connection = new SqliteConnection(connectionString);
connection.Open();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connection, b => b.MigrationsAssembly("Infrastructure")));
builder.Services.AddScoped<IFlightRepository , FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddScoped<IUserClientRepository, UserClientRepository>();
builder.Services.AddScoped<IUserClientService, UserClientService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserAirlineRepository, UserAirlineRepository>();
builder.Services.AddScoped<IUserAirlineService, UserAirlineService>();

builder.Services.AddScoped<IAutenticationService, AutenticationService>();
builder.Services.Configure<AutenticationServiceOptions>(
     builder.Configuration.GetSection(AutenticationServiceOptions.AutenticacionService)
    );

builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticaci�n que tenemos que elegir despu�s en PostMan para pasarle el token
    .AddJwtBearer(options => //Ac� definimos la configuraci�n de la autenticaci�n. le decimos qu� cosas queremos comprobar. La fecha de expiraci�n se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AutenticacionService:Issuer"],
            ValidAudience = builder.Configuration["AutenticacionService:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AutenticacionService:SecretForKey"]))
        };
    }
);


//Swagger configuracion para usar token

builder.Services.AddSwaggerGen(setupAction =>
{
setupAction.AddSecurityDefinition("DreamAirApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
{
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    Description = "Ac� pegar el token generado al loguearse."
});

setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "DreamAirApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });

});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("admin"));
    options.AddPolicy("AirlinePolicy", policy => policy.RequireRole("airline"));
    options.AddPolicy("ClientPolicy", policy => policy.RequireRole("client"));
    options.AddPolicy("AdminOrAirlinePolicy", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("admin") ||
            context.User.IsInRole("airline")));
    //options.AddPolicy("AdminOrClient", policy =>
    //    policy.RequireAssertion(context =>
    //        context.User.IsInRole("admin") ||
    //        context.User.IsInRole("client")));
    //options.AddPolicy("EveryoneExceptGuests", policy =>
    //    policy.RequireAssertion(context =>
    //        context.User.IsInRole(UserType.Customer.ToString()) ||
    //        context.User.IsInRole(UserType.Seller.ToString()) ||
    //        context.User.IsInRole(UserType.Admin.ToString())));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var app = builder.Build();
app.UseCors("AllowLocalhost5173");
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
