using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Models
{
    public class ComputerContext : DbContext
    {
        public ComputerContext(DbContextOptions<ComputerContext> options) :base(options) 
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Item> items { get; set; }

        public DbSet<ItemType> itemTypes { get; set; }


    }
}
