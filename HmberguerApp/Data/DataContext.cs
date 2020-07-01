using HmberguerApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HmberguerApp.Data
{
    public class DataContext: DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
        {
        }

        public virtual DbSet<Burgers> Contacto { get; set; }
        public virtual DbSet<Usuarios> Usuario { get; set; }
    }
}
