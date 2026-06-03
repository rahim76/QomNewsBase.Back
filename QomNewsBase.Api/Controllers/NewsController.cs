using MediatR;
using Microsoft.AspNetCore.Mvc;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Api.Controllers;

public class NewsController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken, string? title, int viewsCount, int newsGroupId, int pageNumber = 1, int pageSize = 10)
    {
        var result = await sender.Send(new GetAllNewsQuery(title, viewsCount, newsGroupId, pageNumber, pageSize), cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetOneNewsQuery(id), cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("MostViewedNews/{newsGroupId:int}")]
    public async Task<IActionResult> MostViewedNews(int newsGroupId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new MostViewedNewsQuery(newsGroupId), cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateNewsCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] UpdateNewsCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteNewsCommand(id), cancellationToken);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

}