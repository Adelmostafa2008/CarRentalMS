using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasOne(x => x.customerProfile).WithOne(x => x.customer);
            modelBuilder.Entity<Car>().HasMany(x => x.rentalTransactions).WithOne(x => x.car);
            modelBuilder.Entity<Customer>().HasMany(x => x.rentalTransactions).WithOne(x => x.customer);
            modelBuilder.Entity<Car>().HasMany(x => x.MaintenanceRecord).WithOne(x => x.car);
            modelBuilder.Entity<Branch>().HasMany(x => x.cars).WithOne(x => x.branch);

            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, Name = "AutoFleet Giza", City = "Giza", Capacity = 20 },
                new Branch { Id = 2, Name = "AutoFleet Cairo", City = "Cairo", Capacity = 25 },
                new Branch { Id = 3, Name = "AutoFleet Alexandria", City = "Alexandria", Capacity = 15 },
                new Branch { Id = 4, Name = "AutoFleet Mansoura", City = "Mansoura", Capacity = 10 }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Model = "Corolla", Brand = "Toyota", PlateNumber = "GYZ1234", Status = "Available", DailyRate = 700, BranchId = 1 },
                new Car { Id = 2, Model = "Civic", Brand = "Honda", PlateNumber = "CAI4567", Status = "Rented", DailyRate = 750, BranchId = 2 },
                new Car { Id = 3, Model = "Elantra", Brand = "Hyundai", PlateNumber = "ALX8901", Status = "Available", DailyRate = 650, BranchId = 3 },
                new Car { Id = 4, Model = "Model 3", Brand = "Tesla", PlateNumber = "CAI2222", Status = "Maintenance", DailyRate = 1500, BranchId = 2 },
                new Car { Id = 5, Model = "Camry", Brand = "Toyota", PlateNumber = "GYZ7777", Status = "Rented", DailyRate = 900, BranchId = 1 },
                new Car { Id = 6, Model = "Focus", Brand = "Ford", PlateNumber = "MAN1100", Status = "Available", DailyRate = 600, BranchId = 4 },
                new Car { Id = 7, Model = "X5", Brand = "BMW", PlateNumber = "ALX5500", Status = "Available", DailyRate = 1300, BranchId = 3 },
                new Car { Id = 8, Model = "Kicks", Brand = "Nissan", PlateNumber = "CAI9090", Status = "Rented", DailyRate = 680, BranchId = 2 },
                new Car { Id = 9, Model = "Sonata", Brand = "Hyundai", PlateNumber = "GYZ2244", Status = "Available", DailyRate = 850, BranchId = 1 },
                new Car { Id = 10, Model = "CX-5", Brand = "Mazda", PlateNumber = "MAN3344", Status = "Available", DailyRate = 950, BranchId = 4 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Ahmed Hassan", Email = "ahmed.hassan@example.com", Phone = "01012345678" },
                new Customer { Id = 2, Name = "Mona Ali", Email = "mona.ali@example.com", Phone = "01122334455" },
                new Customer { Id = 3, Name = "Khaled Youssef", Email = "khaled.youssef@example.com", Phone = "01099887766" },
                new Customer { Id = 4, Name = "Sara Ibrahim", Email = "sara.ibrahim@example.com", Phone = "01233445566" },
                new Customer { Id = 5, Name = "Youssef Adel", Email = "youssef.adel@example.com", Phone = "01077665544" },
                new Customer { Id = 6, Name = "Omar Elsayed", Email = "omar.elsayed@example.com", Phone = "01166778899" },
                new Customer { Id = 7, Name = "Heba Mohamed", Email = "heba.mohamed@example.com", Phone = "01088997766" },
                new Customer { Id = 8, Name = "Tarek Samir", Email = "tarek.samir@example.com", Phone = "01299001122" },
                new Customer { Id = 9, Name = "Laila Magdy", Email = "laila.magdy@example.com", Phone = "01155002233" },
                new Customer { Id = 10, Name = "Mahmoud Nabil", Email = "mahmoud.nabil@example.com", Phone = "01077001122" }
            );

            modelBuilder.Entity<CustomerProfile>().HasData(
                new CustomerProfile { Id = 1, Address = "Giza, El Haram", LicenseNumber = "L12345", LicenseExpiry = new DateTime(2027, 5, 12), CustomerId = 1},
                new CustomerProfile { Id = 2, Address = "Nasr City, Cairo", LicenseNumber = "L22346", LicenseExpiry = new DateTime(2026, 3, 1),  CustomerId = 2},
                new CustomerProfile { Id = 3, Address = "Smouha, Alexandria", LicenseNumber = "L32347", LicenseExpiry = new DateTime(2028, 7, 19),  CustomerId = 3},
                new CustomerProfile { Id = 4, Address = "Zamalek, Cairo", LicenseNumber = "L42348", LicenseExpiry = new DateTime(2029, 2, 9),  CustomerId = 4},
                new CustomerProfile { Id = 5, Address = "Dokki, Giza", LicenseNumber = "L52349", LicenseExpiry = new DateTime(2027, 12, 14),  CustomerId = 5},
                new CustomerProfile { Id = 6, Address = "Mansoura, Dakahlia", LicenseNumber = "L62350", LicenseExpiry = new DateTime(2025, 9, 30),  CustomerId = 6},
                new CustomerProfile { Id = 7, Address = "Cairo, Maadi", LicenseNumber = "L72351", LicenseExpiry = new DateTime(2028, 1, 25),  CustomerId = 7},
                new CustomerProfile { Id = 8, Address = "Alexandria, Montaza", LicenseNumber = "L82352", LicenseExpiry = new DateTime(2029, 8, 11),  CustomerId = 8},
                new CustomerProfile { Id = 9, Address = "Cairo, Shoubra", LicenseNumber = "L92353", LicenseExpiry = new DateTime(2026, 4, 3),  CustomerId = 9},
                new CustomerProfile { Id = 10, Address = "Giza, Faisal", LicenseNumber = "L10354", LicenseExpiry = new DateTime(2027, 11, 20),  CustomerId = 10}
            );

            modelBuilder.Entity<RentalTransaction>().HasData(
            new RentalTransaction { Id = 1, CustomerId = 1, CarId = 2, StartDate = new DateTime(2025, 10, 1), EndDate = new DateTime(2025, 10, 10), Status = "Completed" },
            new RentalTransaction { Id = 2, CustomerId = 2, CarId = 5, StartDate = new DateTime(2025, 10, 12), EndDate = new DateTime(2025, 10, 18), Status = "Active" },
            new RentalTransaction { Id = 3, CustomerId = 3, CarId = 8, StartDate = new DateTime(2025, 9, 20), EndDate = new DateTime(2025, 9, 25), Status = "Completed" },
            new RentalTransaction { Id = 4, CustomerId = 4, CarId = 1, StartDate = new DateTime(2025, 8, 5), EndDate = new DateTime(2025, 8, 12), Status = "Canceled" },
            new RentalTransaction { Id = 5, CustomerId = 5, CarId = 7, StartDate = new DateTime(2025, 10, 5), EndDate = new DateTime(2025, 10, 15), Status = "Active" },
            new RentalTransaction { Id = 6, CustomerId = 6, CarId = 3, StartDate = new DateTime(2025, 9, 10), EndDate = new DateTime(2025, 9, 13), Status = "Completed" },
            new RentalTransaction { Id = 7, CustomerId = 7, CarId = 6, StartDate = new DateTime(2025, 10, 8), EndDate = new DateTime(2025, 10, 12), Status = "Active" },
            new RentalTransaction { Id = 8, CustomerId = 8, CarId = 9, StartDate = new DateTime(2025, 10, 1), EndDate = new DateTime(2025, 10, 9), Status = "Completed" },
            new RentalTransaction { Id = 9, CustomerId = 9, CarId = 10, StartDate = new DateTime(2025, 9, 28), EndDate = new DateTime(2025, 10, 5), Status = "Completed" },
            new RentalTransaction { Id = 10, CustomerId = 10, CarId = 4, StartDate = new DateTime(2025, 10, 7), EndDate = new DateTime(2025, 10, 14), Status = "Active" }
            );


            modelBuilder.Entity<MaintenanceRecord>().HasData(
                new MaintenanceRecord { Id = 1, CarId = 4, Date = new DateTime(2025, 9, 10), Description = "Battery replacement", Cost = 4500 },
                new MaintenanceRecord { Id = 2, CarId = 4, Date = new DateTime(2025, 8, 5), Description = "Tire alignment", Cost = 900 },
                new MaintenanceRecord { Id = 3, CarId = 2, Date = new DateTime(2025, 6, 15), Description = "Oil change", Cost = 700 },
                new MaintenanceRecord { Id = 4, CarId = 8, Date = new DateTime(2025, 5, 10), Description = "Brake pads replacement", Cost = 2500 },
                new MaintenanceRecord { Id = 5, CarId = 7, Date = new DateTime(2025, 3, 22), Description = "AC system repair", Cost = 3500 },
                new MaintenanceRecord { Id = 6, CarId = 3, Date = new DateTime(2025, 2, 19), Description = "Engine tuning", Cost = 2700 }
            );
        }
        
        public DbSet<Car> car { get; set; }
        public DbSet<Branch> branch { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<CustomerProfile> customerProfile { get; set; }
        public DbSet<MaintenanceRecord> maintenanceRecord { get; set; }
        public DbSet<RentalTransaction> rentalTransaction { get; set; }

    }
}