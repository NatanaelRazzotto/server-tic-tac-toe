using Microsoft.EntityFrameworkCore;

namespace server_tic_tac_toe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
       
    }
}
