using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reservator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservator.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserInfo>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public override DbSet<UserInfo> Users { get; set; }
    }
}
