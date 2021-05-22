using ExamenVanguardia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenVanguardia.Context
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<CategoriaEvento> CategoriaEvento { get; set; }
     




        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=database-1.cwyafa0gf6ea.us-east-1.rds.amazonaws.com,1433;Database=Examen;User Id=admin;Password=hola1234");
        }
    }
}
