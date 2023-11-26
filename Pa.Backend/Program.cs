using Microsoft.EntityFrameworkCore;
using Pa.Backend.Dal;
using Pa.Backend.Interfaces;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSingleton<IImageRepository, ImagesRepository>();
    // builder.Services.AddSingleton<ISessionService, SessionsService>();
    builder.Services.AddControllers();
    builder.Services.AddDbContext<PaContext>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
// Configure the HTTP request pipeline.
