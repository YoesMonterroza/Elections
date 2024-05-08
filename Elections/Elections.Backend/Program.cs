using Elections.Backend.Data;
using Elections.Backend.Repositories;
using Elections.Backend.Repositories.Implementations;
using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Implementations;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name =LocalConnection"));
builder.Services.AddTransient<SeedDb>();



// UnitOfWork
builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped<ICountriesUnitOfWork, CountriesUnitOfWork>();
builder.Services.AddScoped<IStatesUnitOfWork, StatesUnitOfWork>();
builder.Services.AddScoped<ICitiesUnitOfWork, CitiesUnitOfWork>();
builder.Services.AddScoped<IZoningsUnitOfWork, ZoningsUnitOfWork>();
builder.Services.AddScoped<IVotingStationsUnitOfWork, VotingStationsUnitOfWork>();
builder.Services.AddScoped<IElectoralJourneysUnitOfWork, ElectoralJourneysUnitOfWork>();
builder.Services.AddScoped<IElectoralPositionsUnitOfWork, ElectoralPositionsUnitOfWork>();
builder.Services.AddScoped<ISexesUnitOfWork, SexesUnitOfWork>();
builder.Services.AddScoped<IUsersUnitOfWork, UsersUnitOfWork>();

// Repository
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStatesRepository, StatesRepository>();
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<IZoningsRepository, ZoningsRepository>();
builder.Services.AddScoped<IVotingStationsRepository, VotingStationsRepository>();
builder.Services.AddScoped<IElectoralJourneysRepository, ElectoralJourneysRepository>();
builder.Services.AddScoped<IElectoralPositionsRepository, ElectoralPositionsRepository>();
builder.Services.AddScoped<ISexesRepository, SexesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    x.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
    x.SignIn.RequireConfirmedEmail = true;
    x.User.RequireUniqueEmail = true;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    x.Lockout.MaxFailedAccessAttempts = 5;
    x.Lockout.AllowedForNewUsers = true;
})
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());

app.Run();