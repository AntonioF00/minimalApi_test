using minimalApi_test.Components;
using minimalApi_test.Datas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add components
builder.Services.AddSingleton<IRequestsCounter, RequestsCounter>();
builder.Services.AddSingleton<IDataManager, DataManager>();
builder.Services.AddSingleton<IOutputGetTickets, OutputGetTickets>();
builder.Services.AddSingleton<IInputBuyTickets, InputBuyTickets>();
builder.Services.AddSingleton<IOutputBuyTickets, OutputBuyTickets>();
builder.Services.AddSingleton<IOutputError, OutputError>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();