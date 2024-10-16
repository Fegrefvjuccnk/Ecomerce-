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
    public class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
            builder.OwnsOne(Address=>Address.shipingaddress,shipingaddress=>shipingaddress.WithOwner());//to create address with total between 
            builder.Property(p => p.Subtotal).
                HasColumnType(" decimal(18,2)");
          

            builder.Property(p => p.orderstatues).
                HasConversion(ostatus => ostatus.ToString(),
                ostaues=>(OrderStatues) Enum.Parse(typeof(OrderStatues),ostaues)
                );

        }
    }
}
