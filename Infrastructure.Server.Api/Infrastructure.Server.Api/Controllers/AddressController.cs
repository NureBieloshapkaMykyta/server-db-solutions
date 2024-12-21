using Application.Abstractions;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Server.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AddressController(IRepository<Address> repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await repository.Get());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Address entity)
    {
        var result = await repository.Add(entity);
        if (!result)
        {
            return BadRequest();
        }

        return Ok();
    }
}
