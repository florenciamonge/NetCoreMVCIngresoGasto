using ControlIngresoGasto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlIngresoGasto.Data
{
    public class ApplicationDbContext : DbContext
    {   
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        //Propìedades
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<IngresoGasto> IngresoGastos { get; set; }

    }
}
