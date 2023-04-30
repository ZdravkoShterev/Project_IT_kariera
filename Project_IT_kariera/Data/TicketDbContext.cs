using Microsoft.EntityFrameworkCore;
using Project_IT_kariera.Models;

namespace Project_IT_kariera.Data
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options)
        {

        }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
