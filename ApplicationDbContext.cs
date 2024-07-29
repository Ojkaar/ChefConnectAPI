using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    // Añadir DbSet para otras tablas si es necesario
}

public class User
{
    public long id { get; set; }
    public string name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}
