using currencyExchangeService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace currencyExchangeService.Infrastructure.Persistence.Configurations
{
    public class MarkupSettingConfiguration : IEntityTypeConfiguration<MarkupSetting>
    {
        public void Configure(EntityTypeBuilder<MarkupSetting> builder)
        {
            builder.Property(m => m.MarkupSettingPercentage)
                .IsRequired();
        }
    }
}
