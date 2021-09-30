using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI.DataBase
{
    public class EntitiesDbContext : DbContext
    {
        public EntitiesDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Entities> Entities { get; set; }
    }
}