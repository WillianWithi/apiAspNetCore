using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICSHARP.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteTelefone> ClienteTelefone{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
