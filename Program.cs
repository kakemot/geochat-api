using geo;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.MapGet("/messages", () =>
{       
        DbService dbs = new DbService();
        Message msg = new Message();
        msg.Username = "bro-bro";
        msg.City = "Trondheim";
        msg.Locality = "Tiller";
        msg.Content = "Dette funker såååå bra da";
        msg.Time = DateTime.Now;
        List<Message> messages = new List<Message>();
        messages.Add(msg);
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