using MediatR;
using Microsoft.AspNetCore.Mvc;
using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Api.Controllers;

public class CommentController(ISender sender) : BaseController
{
    [HttpGet("GetByNewsId/{newsId:guid}")]
    public async Task<IActionResult> GetByNewsId(Guid newsId, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetCommentsByNewsIdQuery(newsId), cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetLastComments/{takeCommensCount:int}")]
    public async Task<IActionResult> GetLastComments(CancellationToken cancellationToken, int takeCommensCount = 10)
    {
        var result = await sender.Send(new GetLastCommentsQuery() { TakeCommensCount = takeCommensCount }, cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCommentCommand command, CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCommentCommand(id), cancellationToken);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }



}