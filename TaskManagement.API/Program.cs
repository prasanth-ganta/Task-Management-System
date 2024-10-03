
using TaskManagement.Services.Implementations;
using TaskManagement.Services.Interfaces;
using TaskManagement.DataBase.IDataBaseOperations;
using TaskManagement.DataBase.DataBaseOperations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITaskService,TaskService>();
builder.Services.AddSingleton<IUserService,UserService>();
builder.Services.AddTransient<IDatabaseOptions,DataBaseOperation>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
