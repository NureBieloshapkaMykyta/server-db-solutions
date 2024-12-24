using Application.Abstractions;
using Application.Implementations;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlatController(IRepository<Flat> repository, IInfrastructureService infrastructureService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await repository.Get());
    }

    [HttpGet("less-than-avg-size-count")]
    public async Task<IActionResult> GetLessThanAvgSizeCount()
    {
        return Ok(await infrastructureService.GetLessThanAvgFlatSize());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Flat entity)
    {
        var result = await repository.Add(entity);
        if (!result)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPost("catch-exception-on-insert")]
    public async Task<IActionResult> AddWithException(short size, bool hasBalcony, bool hasParkingSpace, bool isRented, long? entranceId)
    {
        var result = await infrastructureService.GetInsertFlatException(size, hasBalcony, hasParkingSpace, isRented, entranceId);

        return Ok(result);
    }
}
