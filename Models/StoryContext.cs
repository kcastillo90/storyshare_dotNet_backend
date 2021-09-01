using Microsoft.EntityFrameworkCore;

namespace storyshare_dotNet_backend.Models
{
  public class StoryContext : DbContext
  {
    public StoryContext(DbContextOptions<StoryContext> options) : base(options)
    {
    }
    public DbSet<Story> Stories {get; set;}
  }
}
