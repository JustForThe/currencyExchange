using currencyExchangeService.Domain.Common;
using System.Threading.Tasks;

namespace currencyExchangeService.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
