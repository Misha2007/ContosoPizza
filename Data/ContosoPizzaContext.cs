using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Data
{
    public class ContosoPizzaContext : DbContext
    {
        public ContosoPizzaContext(DbContextOptions<ContosoPizzaContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; } = null!;
    }
}
