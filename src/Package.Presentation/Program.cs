var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PackageDb")));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Package.Application.UseCases.Subscription.Commands.CreateSubscription.CreateSubscriptionCommand>());

builder.Services.AddValidatorsFromAssembly(typeof(ISubscriptionRepository).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

builder.Services.AddSingleton<IRedisCache>(sp =>
    new RedisCache(builder.Configuration["Redis:ConnectionString"]!));

builder.Services.AddHostedService<CacheUpdater>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
