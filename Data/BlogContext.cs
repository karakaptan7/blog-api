using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data;

public class BlogContext : DbContext
{
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }
}