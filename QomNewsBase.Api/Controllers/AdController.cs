using MediatR;
using Microsoft.AspNetCore.Mvc;
using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Api.Controllers;
public class AdController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(string? title, DateTime? startDate, DateTime? endDate,
        bool? isActive, long? clickCount, int? positionType, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAllAdQuery(title, startDate, endDate, isActive, clickCount, positionType), cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateAdCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteAdCommand(id), cancellationToken);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);

    }

}