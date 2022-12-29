using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        /// <summary>
        /// Represents our Users table inside db
        /// </summary>
        /// <value></value>
        public DbSet<AppUser> Users { get; set; }
    }
}