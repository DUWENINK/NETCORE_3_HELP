using DUWENINK.Core.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DUWENINK.Core.Data.Configurations
{
    /// <summary>
    /// Base信息配置
    /// </summary>
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //配置全局过滤器
            //India Assam do this wrong maybe
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.Property(e => e.CreateUserId).HasMaxLength(36);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);
        }
    }
}
