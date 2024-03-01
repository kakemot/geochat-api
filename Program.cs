using geo;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();



app.MapGet("/allmessages", async () =>
{       
        DbService dbs = new DbService();
        List<Message> messages = await dbs.GetMessages();
    return messages;
})
.WithName("GetMessages")
.WithOpenApi();

app.MapGet("/messages", async (DateTime lastChecked, string city) =>
{       
    DbService dbs = new DbService();
    List<Message> messages = await dbs.GetMessagesByCity(lastChecked, city); // Assuming you'll implement this method
    return messages;
})
.WithName("GetMessagesByCity")
.WithOpenApi();

app.MapGet("/hasNewMessages", async (DateTime lastChecked, string city) =>
{
    DbService dbs = new DbService();
    bool hasNewMessages = await dbs.HasNewMessagesSince(lastChecked, city);
    return hasNewMessages;
})
.WithName("HasNewMessages")
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
app.UseCors();
app.Run();