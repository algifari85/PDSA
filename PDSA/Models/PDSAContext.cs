using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PDSA.Models
{
    public class PDSAContext : DbContext
    {
        public PDSAContext(DbContextOptions<PDSAContext> options)
            :base(options)
        { }
        
        public DbSet<Unit> Units { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Problem> Problems { get; set; }
    }
}
