using Application.Abstractions;
using Application.Implementations;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlatController(IRepository<Flat> repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await repository.Get());
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
}
