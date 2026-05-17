using Czwiczenie_10.Data;
using Czwiczenie_10.Dtos;

namespace Czwiczenie_10.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _context;

    public DbService(AppDbContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<GetPcDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetPcComponentDetailsDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<GetPcDto> CreatePcAsync(CreatePcDto createPc)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdatePcAsync(int Id, EditPcDto editPc)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}