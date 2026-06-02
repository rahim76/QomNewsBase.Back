using MediatR;
using Microsoft.AspNetCore.Mvc;
using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Api.Controllers;
public class AdController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateAdCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}