using AutoMapper;
using PersonalTable.Services;
using PersonalTable.Utiliteis;
using PersonalTable.Model.Configurations;

var builder = WebApplication.CreateBuilder(args);


// Settings CORS
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

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Connecting to databases
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(connection);
});

// Page settings
var pageSettings = builder.Configuration.GetSection("PageSettings");
builder.Services.Configure<PageSettings>(pageSettings);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service registration
builder.Services.AddTransient<IPersonServices, PersonServices>();
builder.Services.AddTransient<ISearchPersonServices, SearchPersonServices>();

// Ьapper setting
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

// Mapper service registration
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
