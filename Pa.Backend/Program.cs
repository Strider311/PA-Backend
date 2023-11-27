using Pa.Backend.Dal;
using Pa.Backend.Interfaces;
using Pa.Backend.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<PaContext>();
    builder.Services.AddScoped<IImageService, ImageService>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();
    app.Run();
}
// Configure the HTTP request pipeline.