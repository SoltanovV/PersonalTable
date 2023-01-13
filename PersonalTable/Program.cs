using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalTable.Model;
using PersonalTable.Services;
using PersonalTable.Services.Interface;
using PersonalTable.Utiliteis;

var builder = WebApplication.CreateBuilder(args);


// Натсройка CORS
builder.Services.AddCors(options =>
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowCredentials()
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:5500");
        }));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Создание зависимости
builder.Services.AddTransient<IPersonCreate, PersonCreate>();
builder.Services.AddTransient<ISearchPerson, SearchPerson>();

// Настройка конфигурации 
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
// Создание зависимости
builder.Services.AddSingleton(mapper);
// Добавления маппинга
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Получение строки подключения
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Передача строки подключения
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(connection);
});

var app = builder.Build();

app.UseCors("CORSPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
