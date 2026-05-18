using Czwiczenie_10.Data;
using Czwiczenie_10.Dtos;
using Czwiczenie_10.Models;
using Microsoft.EntityFrameworkCore;

namespace Czwiczenie_10.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _context;

    public DbService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<GetPcDto>> GetAllAsync()
    {
        return await _context.Pcs
            .Select(x => new GetPcDto
            {
                Id = x.Id,
                Name = x.Name,
                Weight = x.Weight,
                Warranty = x.Warranty,
                CreatedAt = x.CreatedAt,
                Stock = x.Stock
            })
            .ToListAsync();
    }

    public async Task<GetPcComponentDetailsDto?> GetByIdAsync(int id)
    {
        return await _context.Pcs
            .Where(x => x.Id == id)
            .Select(pc => new GetPcComponentDetailsDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock,
                Components = pc.PcComponents.Select(x => new GetPcComponentDto
                {
                    Amount = x.Amount,
                    Component = new GetComponentDto
                    {
                        Code = x.Component.Code,
                        Name = x.Component.Name,
                        Description = x.Component.Description,
                        Manufacturer = new GetManufacturerDto
                        {
                            Id = x.Component.Manufacturer.Id,
                            Abbreviation = x.Component.Manufacturer.Abbreviation,
                            FullName = x.Component.Manufacturer.FullName,
                            FoundationDate = x.Component.Manufacturer.FoundationDate
                        },
                        Type = new GetComponentTypeDto
                        {
                            Id = x.Component.ComponentType.Id,
                            Abbreviation = x.Component.ComponentType.Abbreviation,
                            Name = x.Component.ComponentType.Name
                        }
                    }
                }).ToList()
            }).FirstOrDefaultAsync();
    }

    public async Task<GetPcDto> CreatePcAsync(CreatePcDto createPc)
    {
        var pc = new Pc
        {
            Name = createPc.Name,
            Weight = createPc.Weight,
            Warranty = createPc.Warranty,
            CreatedAt = createPc.CreatedAt,
            Stock = createPc.Stock
        };
        _context.Pcs.Add(pc);
        await _context.SaveChangesAsync();
        return new GetPcDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdatePcAsync(int id, EditPcDto editPc)
    {
        var pc = await _context.Pcs
            .FirstOrDefaultAsync(x => x.Id == id);
        if (pc == null)
        {
            return false;
        }

        pc.Name = editPc.Name;
        pc.Weight = editPc.Weight;
        pc.Warranty = editPc.Warranty;
        pc.CreatedAt = editPc.CreatedAt;
        pc.Stock = editPc.Stock;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.Pcs
            .FirstOrDefaultAsync(x => x.Id == id);
        if (pc == null)
        {
            return false;
        }

        _context.Pcs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
}