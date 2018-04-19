using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Entities;

namespace Restaurant.DAL.EF
{
    public class ApplicationDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly ConnectionStringDto _connectionStringDto;

        // Table properties e.g
        // public virtual DbSet<Entity> TableName { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SmallTable> SmallTables { get; set; }
        public DbSet<StatusReservation> StatusReservations { get; set; }

        public ApplicationDbContext(ConnectionStringDto connectionStringDto)
        {
            _connectionStringDto = connectionStringDto;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionStringDto.ConnectionString); // for provider SQL Server 
            // optionsBuilder.UseMySql(_connectionStringDto.ConnectionString); //for provider My SQL 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API commands

            modelBuilder.Entity<SmallTableReservation>()
                .HasKey(bc => new { bc.SmallTableId, bc.ReservationId });

            modelBuilder.Entity<SmallTableReservation>()
                .HasOne(bc => bc.SmallTable)
                .WithMany(b => b.Reservations)
                .HasForeignKey(bc => bc.SmallTableId);

            modelBuilder.Entity<SmallTableReservation>()
                .HasOne(bc => bc.Reservation)
                .WithMany(c => c.SmallTables)
                .HasForeignKey(bc => bc.ReservationId);
        }
    }
}