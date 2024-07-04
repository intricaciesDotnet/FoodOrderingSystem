using FoodOrderingSystem.Application.ServiceRegisterations;
using FoodOrderingSystem.Infrastructure.Modals;
using FoodOrderingSystem.Infrastructure.ServiceRegisterations;
using FoodOrderingSystem.Persistence.ServiceRegisterations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FoodOrderDatabaseSettings>(
    builder.Configuration.GetSection(FoodOrderingSystem.WebAPI.Consts.Constants.Name));

builder.Services.AddMediatR(opt => 
    opt.RegisterServicesFromAssembly
    (FoodOrderingSystem.Application.Abstractions.AssemblyReference.Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration)
    .AddPresistenceLayer();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var seeder = scope.ServiceProvider.GetRequiredService<UserDataSeeder>();
//    await seeder.SeedData();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
