using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites;

namespace Talbat.Repostory.DtoMAPPER
{
   public class BasketCustomerDtos
    {
        [Required]
        public string Id { get; set; }
     
        public List<BasketItemDtos> BasketItems { get; set; }
        public int? DeliveryItemID { get; set; }
        public string? ClientSecret { get; set; }
        public string? Paymentintenid { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
