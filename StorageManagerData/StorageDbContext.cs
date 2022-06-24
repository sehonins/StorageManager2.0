using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagerData
{
    internal class StorageDbContext: DbContext
    {
        public DbSet<Emploee> emploees { get; set; }
        private string sqlServe = "Server=(localdb)\\mssqllocaldb;Database=StorageDb";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlServe);
        }
    }
}
 