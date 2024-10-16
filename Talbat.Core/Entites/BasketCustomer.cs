using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talbat.Core.Entites
{

 public class BasketCustomer
    {
        public BasketCustomer(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public int? DeliveryItemID { get; set; }
        public string  ClientSecret { get; set; }
        public string?Paymentintenid { get; set; }
        public decimal ShippingCost { get; set; }
    }
}
