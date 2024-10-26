using InfoSystem_Drivers_U3.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace U3_Infosystem_ASP.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Employees
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 1,
                Name = "Chris",
                Email = "Chris@knug.se",
                Password = "jagärbäst",
                Role = "Admin"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 2,
                Name = "Jonas Rikke",
                Email = "Jonas.Riqqe@Driverman.com",
                Password = "Rikke",
                Role = "Employee"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 3,
                Name = "Helene Örnholm",
                Email = "H.Ornholm@Queen.com",
                Password = "Queen",
                Role = "Employee"
            });

            // Drivers
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 1,
                DriverName = "Steffe",
                CarReg = "OAG112",
                NoteDate = DateTime.Now,
                NoteDescription = "Delivered supplies",
                ResponsibleEmployee = "Steffe",
                BeloppUt = 200.00M,
                BeloppIn = 1000.00M,
                TotalBeloppUt = 200.00M,
                TotalBeloppIn = 1000.00M
            });
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 2,
                DriverName = "Roffe",
                CarReg = "OKO340",
                NoteDate = DateTime.Now.AddDays(-3),
                NoteDescription = "Added Fuel",
                ResponsibleEmployee = "Jonas",
                BeloppUt = 500.00M,
                BeloppIn = 0.00M,
                TotalBeloppUt = 500.00M,
                TotalBeloppIn = 0.00M
            });
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 3,
                DriverName = "Anita",
                CarReg = "UFG198",
                NoteDate = DateTime.Now.AddDays(-2),
                NoteDescription = "Delivered supplies",
                ResponsibleEmployee = "Helene",
                BeloppUt = 100.00M,
                BeloppIn = 1000.00M,
                TotalBeloppUt = 100.00M,
                TotalBeloppIn = 1000.00M
            });
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 4,
                DriverName = "Håkan",
                CarReg = "KAD441",
                NoteDate = DateTime.Now.AddDays(-2),
                NoteDescription = "Delivered supplies",
                ResponsibleEmployee = "Jonas",
                BeloppUt = 200.00M,
                BeloppIn = 2000.00M,
                TotalBeloppUt = 200.00M,
                TotalBeloppIn = 2000.00M
            });
            modelBuilder.Entity<Driver>().HasData(new Driver
            {
                DriverID = 5,
                DriverName = "Ellen",
                CarReg = "PUG962",
                NoteDate = DateTime.Now.AddDays(-3),
                NoteDescription = "Delivered supplies",
                ResponsibleEmployee = "Jonas",
                BeloppUt = 500.00M,
                BeloppIn = 1000.00M,
                TotalBeloppUt = 500.00M,
                TotalBeloppIn = 1000.00M
            });

            // Events
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 1,
                NoteDate = DateTime.Now.AddDays(-3),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 1000.00M,
                DriverID = 1
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 2,
                NoteDate = DateTime.Now,
                NoteDescription = "Fueled Car",
                BeloppUt = 1000.00M,
                BeloppIn = 0.00M,
                DriverID = 2
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 3,
                NoteDate = DateTime.Now.AddDays(-4),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 500.00M,
                DriverID = 3
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 4,
                NoteDate = DateTime.Now.AddDays(-1),
                NoteDescription = "Car Service",
                BeloppUt = 2000.00M,
                BeloppIn = 0.00M,
                DriverID = 4
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 5,
                NoteDate = DateTime.Now.AddDays(-1),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 1800.00M,
                DriverID = 5
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 6,
                NoteDate = DateTime.Now.AddDays(-2),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 700.00M,
                DriverID = 1
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 7,
                NoteDate = DateTime.Now.AddDays(-3),
                NoteDescription = "Delivered supplies",
                BeloppUt = 0.00M,
                BeloppIn = 1200.00M,
                DriverID = 2
            });
        }
    }

}
