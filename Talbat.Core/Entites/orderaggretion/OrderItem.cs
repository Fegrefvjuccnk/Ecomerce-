using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talbat.Core.Entites.orderaggretion
{
    public class OrderItem:BaseEntity
    {
        public OrderItem()
        {
            
        }
        public OrderItem(productOrder productorder, decimal price, int quntity)
        {
            this.productorder = productorder;
            Price = price;
            Quntity = quntity;
        }
   
        public productOrder productorder { get; set; }
        public decimal Price { get; set; }

        public int Quntity { get; set; }
    }
}
