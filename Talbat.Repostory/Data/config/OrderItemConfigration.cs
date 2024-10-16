using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites.orderaggretion;

namespace Talbat.Repostory.Data.config
{
    public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(p => p.productorder, x => x.WithOwner());
            builder.Property(p => p.Price).HasColumnType("   decimal(18,2)");
      
        }
    }
}
