using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites.order;

namespace Talbat.Repostory.Data.config
{
    public class DeliveryItemConfiguration : IEntityTypeConfiguration<Deliveryitem>
    {
        public void Configure(EntityTypeBuilder<Deliveryitem> builder)
        {
            builder.Property(p => p.Cost).HasColumnType("decimal(18,2)");
        

        }
    }
}
