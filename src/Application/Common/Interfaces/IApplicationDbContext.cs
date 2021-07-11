using currencyExchangeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace currencyExchangeService.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<MarkupSetting> MarkupSettings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
