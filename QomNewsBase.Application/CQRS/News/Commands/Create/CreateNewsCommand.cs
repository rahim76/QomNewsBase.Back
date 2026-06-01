using MediatR;
using Microsoft.AspNetCore.Http;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;

public class CreateNewsCommand : IRequest<Result<bool>>
{
    public required string Title { get; set; }
    public IFormFile? Image { get; set; }
    public int NewsGroupId { get; set; }
    public required string Description { get; set; }
}