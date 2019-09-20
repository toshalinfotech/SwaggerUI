using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerUI.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
           : base(options)
        { }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<PortalInfo> PortalInfo { get; set; }
    }
}
