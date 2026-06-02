using QomNewsBase.Application.CQRS;

namespace QomNewsBase.Application.Interfaces;

public interface IAdRepository
{
    Task<List<AdResultDto>> GetAll(GetAllAdQuery query, CancellationToken cancellationToken);
}