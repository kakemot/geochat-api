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
        public async Task<bool> HasNewMessagesSince(DateTime lastChecked, string city)
        {
            await using var dbContext = new MyDbContext();
            dbContext.Database.EnsureCreated();
            bool hasNewMessages = dbContext.Messages.Any(x => x.Time > lastChecked && x.City == city);
            return hasNewMessages;
        }
        public async Task<List<Message>> GetMessagesByCity(DateTime lastChecked, string city)
        {
            await using var dbContext = new MyDbContext();
            dbContext.Database.EnsureCreated();
            List<Message> messages = dbContext.Messages.Where(x => x.Time > lastChecked && x.City == city).ToList();
            return messages;
        }
    }
}