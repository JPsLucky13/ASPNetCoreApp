using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProjectApp.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>();
            //Single Primary Key alternative
            //modelBuilder.Entity<Person>().HasKey(x => x.PersonKey);

            //More than one Primary Key (Composite Key)
            // modelBuilder.Entity<Person>().HasKey(x => new { x.PersonKey, x.FirstName });

            //Required
            //modelBuilder.Entity<Address>().Property(x => x.City).IsRequired();

            //Max Length
            //modelBuilder.Entity<Address>().Property(x => x.ZipCode).HasMaxLength(500);

            //Generated Properties
            //Never Generated Value
            modelBuilder.Entity<Car>().Property(x => x.CarId).ValueGeneratedNever();

            //Value Generated On Add
            modelBuilder.Entity<Car>().Property(x => x.MyDate).ValueGeneratedOnAdd();

            //Value Generated On Add or Update
            modelBuilder.Entity<Car>().Property(x => x.MyDate).ValueGeneratedOnAddOrUpdate();

            //Concurrency Check
            modelBuilder.Entity<Person>().Property(x => x.LastName).IsConcurrencyToken();

            modelBuilder.Entity<Person>().Property(x => x.TimeStamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

            //Indexes
            modelBuilder.Entity<Person>().HasIndex(x => x.FirstName);
            modelBuilder.Entity<Person>().HasIndex(x => x.PersonId).IsUnique();

            //Multiple Column index
            modelBuilder.Entity<Person>().HasIndex(x => new { x.PersonId, x.FirstName });

            //Table Mapping
            modelBuilder.Entity<Address>().ToTable("Addresses",schema:"Address");

            //Column Mapping
            modelBuilder.Entity<Address>().Property(x=>x.StreetName).HasColumnName("StreetAddress");

            //Data Types

            modelBuilder.Entity<Address>().Property(x => x.StreetName).HasColumnType("varchar(300)");

            //Computed Column
            modelBuilder.Entity<Person>().Property(x => x.DisplayName).HasComputedColumnSql("[LastName]+' , '[FirstName]");
        }

        public DbSet<Person> Persons{ get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
