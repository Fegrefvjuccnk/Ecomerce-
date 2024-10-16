using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites.order;
using Talbat.Core.Entites.orderaggretion;

namespace Talbat.Repostory.DtoMAPPER
{
    public class ReturnOrderDto
    {
        public int Id { get; set; }
        public string ByrEmail { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; } 
        public string orderstatues { get; set; } 

        public Address shipingaddress { get; set; }//nevgtional perporty[one]
                                                   //public int DeliveryItemid { get; set; }//ماوراء ال clr
        public string DeliveryItemName { get; set; }
        public decimal Cost { get; set; }

        public ICollection<orderitemdto>  OrderItem { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        
    }
}
