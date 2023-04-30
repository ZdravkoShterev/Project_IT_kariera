using Microsoft.EntityFrameworkCore;
using Project_IT_kariera.Models;

namespace Project_IT_kariera.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
