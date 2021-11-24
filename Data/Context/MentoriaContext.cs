using Data.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MentoriaContext : DbContext
    {
        public MentoriaContext(DbContextOptions<MentoriaContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);

        }
    }
}
