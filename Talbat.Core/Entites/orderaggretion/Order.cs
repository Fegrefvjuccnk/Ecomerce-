using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites.order;

namespace Talbat.Core.Entites.orderaggretion
{
    public class Order:BaseEntity
    {
        public Order()//work it to used entity frameworkcore 
        {
            
        }
        public Order(string byrEmail,  Address shipingaddress, Deliveryitem deliveryitem, ICollection<OrderItem> orderitems, 
            decimal subtotal,string paymentId)
        {
            ByrEmail = byrEmail;
            this.shipingaddress = shipingaddress;
            this.deliveryitem = deliveryitem;
            this.orderitems = orderitems;
            Subtotal = subtotal;
            Paymentid = paymentId;


        }

        public string ByrEmail {  get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }= DateTimeOffset.Now;
        public OrderStatues orderstatues { get; set; } = OrderStatues.pending;

        public Address shipingaddress { get; set; }//nevgtional perporty[one]
        //public int DeliveryItemid { get; set; }//ماوراء ال clr
        public Deliveryitem deliveryitem { get; set; }//nevgtional perporty[one]

        public ICollection<OrderItem> orderitems { get; set; }= new HashSet<OrderItem>();//nevgtional perporty[many]

        public decimal Subtotal { get; set; }
        public decimal Total() => Subtotal + deliveryitem.Cost; 
       public string Paymentid {  get; set; }


    }
}
