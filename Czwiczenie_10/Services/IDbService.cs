using Czwiczenie_10.Dtos;

namespace Czwiczenie_10.Services;

public interface IDbService
{ 
    Task<IEnumerable<GetPcDto>> GetAllAsync();
    Task<GetPcComponentDetailsDto?> GetByIdAsync(int id);
    Task<GetPcDto> CreatePcAsync(CreatePcDto createPc);
    Task<bool> UpdatePcAsync(int Id, EditPcDto editPc);
    Task<bool> DeleteAsync(int id);
}