using CarRent.Application.Features.CQRS.Handlers.BannerHandlers;
using CarRent.Application.Features.CQRS.Handlers.BrandHandlers;
using CarRent.Application.Features.CQRS.Handlers.CarHandlers;
using CarRent.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarRent.Application.Features.CQRS.Handlers.ContactHandlers;
using CarRent.Application.Features.RepositoryPattern;
using CarRent.Application.Interfaces.BlogInterfaces;
using CarRent.Application.Interfaces.CarDescriptionInterfaces;
using CarRent.Application.Interfaces.CarFeatureInterfaces;
using CarRent.Application.Interfaces.CarInterfaces;
using CarRent.Application.Interfaces.CarPricingInterfaces;
using CarRent.Application.Interfaces.RentACarInterfaces;
using CarRent.Application.Interfaces.ReviewInterfaces;
using CarRent.Application.Interfaces.StatisticsInterfaces;
using CarRent.Application.Interfaces.TagCloudInterfaces;
using CarRent.Application.Services;
using CarRent.Application.Tools;
using CarRent.Persistence.Context;
using CarRent.Persistence.Repositories;
using CarRent.Persistence.Repositories.BlogRepositories;
using CarRent.Persistence.Repositories.CarDescriptionRepositories;
using CarRent.Persistence.Repositories.CarFeatureRepositores;
using CarRent.Persistence.Repositories.CarPricingRepositories;
using CarRent.Persistence.Repositories.CarRepository;
using CarRent.Persistence.Repositories.CommentRepositories;
using CarRent.Persistence.Repositories.RentACarRepositories;
using CarRent.Persistence.Repositories.ReviewRepositories;
using CarRent.Persistence.Repositories.StatisticsRepositories;
using CarRent.Persistence.Repositories.TagCloudRepositories;
using CarRent.WebApi.Hubs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using static CarRent.Application.Interfaces.IRepository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

//SignarIR için
//Uygulamamda api'daki verileri frontende tüketmek için izin vermek gibi 
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

// Add services to the container.
builder.Services.AddScoped<CarRentContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLastFiveCarsWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);


//Fluent Validation'u burada tanýmlýyoruz. AddControllers'dan sonra AdaFluentValidation kýsmýný ekliyoruz. Nuget Managerda ise fluenetle alakalý 2 paket yüklüyoruz.
builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//SignalIR için
app.UseCors("CorsPolicy");

//app.UseHttpsRedirection();

////Jwt'den sonra
//app.UseAuthentication();

//app.UseRouting();

//app.MapControllers();
////SignalIr tarafýnda istek yapabileceðiz.
//app.MapHub<CarHub>("/carhub");

//app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});


//app.Run();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");

app.Run();
