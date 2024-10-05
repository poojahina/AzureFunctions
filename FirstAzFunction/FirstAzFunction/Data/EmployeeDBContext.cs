using FirstAzFunction.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAzFunction.Data
{
    public class EmployeeDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> dbContextOptions):base(dbContextOptions)
        {
                
        }

        public Microsoft.EntityFrameworkCore.DbSet<Employee> Employee { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.HasKey(entity => entity.Id);
        //    });
        //}
       
    }
}
