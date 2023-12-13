
using Microsoft.EntityFrameworkCore;

public class ChatContext : DbContext
{
	public ChatContext(DbContextOptions<ChatContext> Options): base(Options)
	{
		//Debug.WriteLine($"{ContextId} context created.");
	}

	public DbSet<User>? Users { get; set; }
	public DbSet<Message>? Messages { get; set; }
}
