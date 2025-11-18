

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

var app = builder.Build();

// Configure the http request pipeline.
app.MapCarter();
app.Run();
