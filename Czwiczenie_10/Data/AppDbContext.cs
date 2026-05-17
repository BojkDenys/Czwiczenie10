using Czwiczenie_10.Models;
using Microsoft.EntityFrameworkCore;

namespace Czwiczenie_10.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<Pc> Pcs { get; set; }
    public DbSet<PCComponent> PcComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComponentType>().HasData(new List<ComponentType>()
        {
            new ComponentType()
            {
                Id = 1,
                Abbreviation = "CPU",
                Name = "processor"
            },
            new ComponentType()
            {
                Id = 2,
                Abbreviation = "GPU",
                Name = "videocard"
            },
            new ComponentType()
            {
                Id = 3,
                Abbreviation = "RAM",
                Name = "memory"
            }
        });
        modelBuilder.Entity<ComponentManufacturer>().HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer()
            {
                Id = 1,
                Abbreviation = "Intel",
                FullName = "Intel corporation",
                FoundationDate = DateTime.Parse("1999-10-10")
            },
            new ComponentManufacturer()
            {
                Id = 2,
                Abbreviation = "AMD",
                FullName = "AMD corporation",
                FoundationDate = DateTime.Parse("1991-12-11")
            },
            new ComponentManufacturer()
            {
                Id = 3,
                Abbreviation = "Nvidia",
                FullName = "Nvidia corporation",
                FoundationDate = DateTime.Parse("1993-10-9")
            }
        });
        modelBuilder.Entity<Component>().HasData(new List<Component>()
        {
            new Component()
            {
                Code = "CPU-1",
                Name = "i9-14900k",
                Description = "Productive processor",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1

            },
            new Component()
            {
                Code = "GPU-1",
                Name = "RTX 4090",
                Description = "Gaming graphic card",
                ComponentManufacturersId = 3,
                ComponentTypesId = 2

            },
            new Component()
            {
                Code = "AMD-1" ,
                Name = "AMD 32Gb" ,
                Description = "DDR 5 RAM",
                ComponentManufacturersId = 2,
                ComponentTypesId = 3
            }
        });
        modelBuilder.Entity<Pc>().HasData(new List<Pc>()
        {
            new Pc()
            {
                Id = 1,
                Name = "Gaming" ,
                Weight = 12 ,
                Warranty = 12,
                CreatedAt = DateTime.Parse("2019-10-6"),
                Stock = 10
            },
            new Pc()
            {
                Id = 2,
                Name = "Office" ,
                Weight = 10,
                Warranty = 24,
                CreatedAt = DateTime.Parse("1999-04-12") ,
                Stock = 36
            },
            new Pc()
            {
                Id = 3,
                Name = "Server" ,
                Weight = 20,
                Warranty = 120,
                CreatedAt = DateTime.Parse("1990-09-19") ,
                Stock = 2
            }

        });
        modelBuilder.Entity<PCComponent>().HasData(new List<PCComponent>()
        {
            new PCComponent()
            {
                PCId = 1,
                ComponentCode = "CPU-1" ,
                Amount = 1
            },
            new PCComponent()
            {
                PCId = 1,
                ComponentCode = "GPU-1",
                Amount = 1
            },
            new PCComponent()
            {
                PCId = 1,
                ComponentCode = "AMD-1" ,
                Amount = 1
            }
        });
        base.OnModelCreating(modelBuilder);
    }
    
}