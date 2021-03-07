using AbstractInstallationSoftwareDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInstallationSoftwareDatabaseImplement
{
    class AbstractInstallSoftDatabase: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-SN533ICB\SQLEXPRESS;Initial Catalog=AbstractInstallSoftDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Package> Package { set; get; }
        public virtual DbSet<PackageComponent> PackageComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
