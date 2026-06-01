using MediatR;
using Microsoft.AspNetCore.Http;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;
public class UpdateNewsCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public required string Description { get; set; }
    public IFormFile? Image { get; set; }
    public int NewsGroupId { get; set; }
}