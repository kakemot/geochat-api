using geo;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.MapGet("/messages", async () =>
{       
        DbService dbs = new DbService();
        List<Message> messages = await dbs.GetMessages();
    return messages;
})
.WithName("GetMessages")
.WithOpenApi();

app.MapPost("/messages", async (Message newMessage) =>
{
    DbService dbs = new DbService();
    await dbs.AddMessage(newMessage);
    newMessage.Time = DateTime.Now; // Set the time to now, assuming it's not set by the client
    return Results.Created($"/messages/{newMessage.Id}", newMessage); // Return the created message
})
.WithName("PostMessage")
.WithOpenApi();
//app.UseHttpsRedirection();
app.Run();