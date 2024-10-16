using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talbat.Core.Entites.order
{
    public class Deliveryitem: BaseEntity
    {
        public Deliveryitem() { }
        public Deliveryitem(string shortName, string descrption, decimal cost, string deliveryTime)
        {
            ShortName = shortName;
            Descrption = descrption;
            Cost = cost;
            DeliveryTime = deliveryTime;
        }

        public string ShortName { get; set; }
        public string Descrption { get; set; }
        public decimal Cost  { get; set; }
        public string DeliveryTime { get; set; }
    }
}
