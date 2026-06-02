using QomNewsBase.Domain.Enums;

namespace QomNewsBase.Application.CQRS;

public class GetAllAdQueryResult
{
    public AdPositionTypeEnum PositionType { get; set; }
    public List<AdResultDto> Ads { get; set; } = [];
}
