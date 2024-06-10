using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<SampleModel1> SampleModel1 { get; set; }
    public DbSet<SampleModel2> SampleModel2 { get; set; }
    public DbSet<SampleModel3> SampleModel3 { get; set; }
    public DbSet<SampleModelJoint> SampleModelJoint { get; set; }
    public DbSet<SampleAssociativeModel> SampleAssociativeModel { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<SampleModel1>().HasData(new List<SampleModel1>
            {
                new SampleModel1 {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new SampleModel1 {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Nowak"
                }
            });

            modelBuilder.Entity<SampleModel2>().HasData(new List<SampleModel2>
            {
                new SampleModel2 {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Nowak"
                },
                new SampleModel2 {
                    Id = 2,
                    FirstName = "Aleksandra",
                    LastName = "Wiśniewska"
                }
            });

            modelBuilder.Entity<SampleModel3>().HasData(new List<SampleModel3>
            {
                new SampleModel3
                {
                    Id = 1,
                    Name = "Drożdzówka",
                    Price = 3.3M,
                    Type = "A"
                },
                new SampleModel3
                {
                    Id = 2,
                    Name = "Babka cytrynowa",
                    Price = 21.23M,
                    Type = "B"
                },
                new SampleModel3
                {
                    Id = 3,
                    Name = "Jagodzianka",
                    Price = 7.2M,
                    Type = "A"
                }
            });

            modelBuilder.Entity<SampleModelJoint>().HasData(new List<SampleModelJoint>
            {
                new SampleModelJoint
                {
                    Id = 1,
                    AcceptedAt = DateTime.Parse("2024-05-28"),
                    FulfilledAt = DateTime.Parse("2024-05-29"),
                    Comments = "Lorem ipsum ...",
                    ClientId = 1,
                    EmployeeId = 2
                },
                new SampleModelJoint
                {
                    Id = 2,
                    AcceptedAt = DateTime.Parse("2024-05-31"),
                    FulfilledAt = DateTime.Parse("2024-06-01"),
                    Comments = "Lorem ipsum ...",
                    ClientId = 1,
                    EmployeeId = 1
                },
                new SampleModelJoint
                {
                    Id = 3,
                    AcceptedAt = DateTime.Parse("2024-06-01"),
                    FulfilledAt = null,
                    Comments = null,
                    ClientId = 2,
                    EmployeeId = 1
                }
            });

            modelBuilder.Entity<SampleAssociativeModel>().HasData(new List<SampleAssociativeModel>
            {
                new SampleAssociativeModel
                {
                    OrderId = 1,
                    PastryId = 1,
                    Amount = 3,
                },
                new SampleAssociativeModel
                {
                    OrderId = 1,
                    PastryId = 3,
                    Amount = 4,
                    Comment = "Lorem ipsum ..."
                },
                new SampleAssociativeModel
                {
                    OrderId = 2,
                    PastryId = 2,
                    Amount = 2
                },
                new SampleAssociativeModel
                {
                    OrderId = 2,
                    PastryId = 1,
                    Amount = 12
                }
            });
    }
}
