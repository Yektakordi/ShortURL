using Microsoft.EntityFrameworkCore;
using UrlShort.Models;

namespace UrlShort.Data
{
    public class UrlDBContext : DbContext
    {
        public UrlDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ShortModel> ShortUrls { get; set; }
    }
}
