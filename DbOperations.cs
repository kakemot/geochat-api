namespace geo
{
    public class DbService
    {
        public async Task<int> AddMessage(Message message)
        {
            await using var dbContext = new MyDbContext();
            dbContext.Database.EnsureCreated();
            var result = await dbContext.AddAsync(message);
            await dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<List<Message>> GetMessages()
        {
            await using var dbContext = new MyDbContext();
            dbContext.Database.EnsureCreated();
            List<Message> messages = dbContext.Messages.ToList();
            return messages;
        }
    }
}