using MassTransit;
using MassTransitTest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMassTransit(configurator =>
{
    configurator.SetKebabCaseEndpointNameFormatter();

    // configurator.AddConsumer<CurrentTimeConsumer>();
    // configurator.AddConsumer<CurrentTimeConsumerV2>();
    configurator.AddConsumers(typeof(Program).Assembly);

    // configurator.UsingInMemory((context, config) =>
    // {
    //     config.ConfigureEndpoints(context);
    // });
    configurator.UsingRabbitMq((context, config) =>
    {
        config.Host(new Uri("amqp://localhost:5672"), hostConfig =>
        {
            hostConfig.Username("guest");
            hostConfig.Password("guest");
        });
        config.ConfigureEndpoints(context);
    });
});

builder.Services.AddHostedService<MessagePublisher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();