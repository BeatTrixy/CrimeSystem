using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Impl
{
    public class CaseContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }

        public CaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}