using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites;
using Talbat.Core.Entites.order;
using Talbat.Core.Entites.orderaggretion;
using Talbat.Core.IGenericRepostory;
using Talbat.Core.Repostory;
using Talbat.Core.Serivces;
using Talbat.Core.Specfication.OrderSpecfaction;
using Talbat.Services.PaymentServices;

namespace Talbat.Services.Services
  {
  public class OrderSerivce : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        //private readonly IGenericRepostiry<Order> _orderrepo;
        //private readonly IGenericRepostiry<Product> _product;
        //private readonly IGenericRepostiry<Deliveryitem> _deliveritems;

        public OrderSerivce(IBasketRepository basketRepository,IUnitOfWork unitOfWork,IPaymentService paymentService /*,IGenericRepostiry<Order> orderrepo
           ,IGenericRepostiry<Product> product,IGenericRepostiry<Deliveryitem>
            Deliveritems*/)
        {
          _basketRepository = basketRepository;
        _unitOfWork = unitOfWork;
            _paymentService = paymentService;
            //_orderrepo = orderrepo;

            //_product = product;
            //    _deliveritems = Deliveritems;
        }
        public async Task<Order?> CreateOrderAsync(string ByerEmail, string BasketId, Address address, int Deliverymethodid)
        {
          //1.create obasket from basket repo
          var basket= await _basketRepository.GetBasketAsync(BasketId);
            //2.Get selecated item at basket from prodeuct repo
            var orderitem = new List<OrderItem>();
            if (basket?.BasketItems?.Count > 0)
            {
                foreach (var item in basket.BasketItems)
                {
                    var product =await _unitOfWork.CreateGenricrepository<Product>().GetById(item.Id);
                    var productorder = new productOrder(product.Id,product.Desctription,product.Name , product.PictureUrl);
                    var order = new OrderItem(productorder, product.Price, item.Quntity);
                    orderitem.Add(order);
                }
            }

            //3.calcaute subtotal
            var subtotal = orderitem.Sum(item => item.Quntity *item.Price);
            //4.Get delivery method from delivery repo
            var delvery= await _unitOfWork.CreateGenricrepository<Deliveryitem>() .GetById(Deliverymethodid);
            //5.create order
            var spc = new Paymentintentspec(basket.Paymentintenid);
            var existingorder = await _unitOfWork.CreateGenricrepository<Order>().GetByspecId(spc);
            if(existingorder != null)
            {
                _unitOfWork.CreateGenricrepository<Order>().Remove(existingorder);
               await _paymentService.CreateOrUpdatePaymentIntent(basket.Id);//check if amount is not updated 
            }
            //put payment id bacuse user checgout in stripe withen paymentid 
            var createorder =new Order(ByerEmail,address, delvery, orderitem,subtotal,basket.Paymentintenid); 
           
          await _unitOfWork.CreateGenricrepository<Order>() .AddAsync(createorder);
            //6.save changes
        var result= await _unitOfWork.completeAsync();
            if (result < 0) return null;
            return createorder;
          
        }

        public async Task<IReadOnlyList<Deliveryitem>> GetDeliveryItemAsync()
        {
            var deliveryitem = await _unitOfWork.CreateGenricrepository<Deliveryitem>().GetAllAsync();
             return deliveryitem;
        }

        public async Task<Order> GetOrdersByTdForUSerAsync(int OrderId, string ByerEmail)
        {
            var spec = new OrderSpecfactions(OrderId, ByerEmail);
            var order = await _unitOfWork.CreateGenricrepository<Order>().GetByspecId(spec);
            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUSerAsync(string ByerEmail)
        {
            var spec=new OrderSpecfactions(ByerEmail);  
            var order = await _unitOfWork.CreateGenricrepository<Order>().GetAllspecAsync(spec);
            return order;
        }

        //public async Task<ActionResult<IReadOnlyList<Deliveryitem>>> GetDeliveryItem()
        //{
        //    var deliveryitem=await _unitOfWork.CreateGenricrepository<Deliveryitem>().GetAllAsync();
        //    return deliveryitem;
        //}

    }
}
    
