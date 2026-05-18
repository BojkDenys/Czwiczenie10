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
    
}