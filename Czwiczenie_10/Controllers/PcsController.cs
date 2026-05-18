using Czwiczenie_10.Dtos;
using Czwiczenie_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Czwiczenie_10.Controllers;

[Route("api/pcs")]
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PcsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _dbService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _dbService.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePc(CreatePcDto createPc)
    {
        var result = await _dbService.CreatePcAsync(createPc);
        return Created("api/pcs/" + result.Id,result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePc(int id, EditPcDto editPc)
    {
        var result = await _dbService.UpdatePcAsync(id, editPc);
        if (!result)
        {
            return NotFound();
        }

        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _dbService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return Ok();
    }
    
    
}