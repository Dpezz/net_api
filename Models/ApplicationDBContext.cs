using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Models
{

    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Articles> Articles { get; set; }

    }

}