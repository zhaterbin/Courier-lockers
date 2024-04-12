﻿using Courier_lockers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courier_lockers.Data
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
         : base(options)
        {
            try
            {
                this.Database.SetCommandTimeout(300);
            }
            catch (Exception ex) { }
        }
        public DbSet<edpmain> edpmains { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<OpearterIn> opearterIns { get; set; }
        public DbSet<Storage> storages { get; set; }
        public DbSet<Operaterout> operaterouts { get; set; }    

        //表和视图
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<edpmain>().HasKey(x => x.Id);

            modelBuilder.Entity<Cell>().HasKey(x => x.CELL_ID);

            modelBuilder.Entity<OpearterIn>().HasKey(x => x.Operator_Id);

            modelBuilder.Entity<Storage>().HasKey(x => x.STORAGE_ID);

            modelBuilder.Entity<Operaterout>().HasKey(x=>x.Operator_Id);
        }
    }
}
