using MediatR;
using QomNewsBase.Application.Common.Results;

namespace QomNewsBase.Application.CQRS;

//خبر های پربازدید
public class MostViewedNewsQuery(int newsGroupId) : IRequest<Result<MostViewedNewsResult>>
{
    public int NewsGroupId { get; set; } = newsGroupId;

}