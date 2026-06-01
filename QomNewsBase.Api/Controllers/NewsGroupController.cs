using MediatR;
using Microsoft.AspNetCore.Mvc;
using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Api.Controllers;

public class NewsGroupController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll(string? title, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAllNewsGroupQuery() { Title = title }, cancellationToken);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}