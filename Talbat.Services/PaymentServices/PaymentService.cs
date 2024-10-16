using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites;
using Talbat.Core.Entites.order;
using Talbat.Core.Repostory;
using Product = Talbat.Core.Entites.Product;

namespace Talbat.Services.PaymentServices
{

    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService( IConfiguration configuration,IBasketRepository basketRepository,
            IUnitOfWork unitOfWork)
        {
         _configuration = configuration;
          _basketRepository = basketRepository;
         _unitOfWork = unitOfWork;
        }
        public async Task<BasketCustomer> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = _configuration["stripconnection:secretkey"];
            var basket=await _basketRepository.GetBasketAsync(basketId);
            if (basket == null) { return null; }
            decimal shippingprice = 0.0m;
            if(basket.DeliveryItemID.HasValue)
            {
                var deliveryitem=await _unitOfWork.CreateGenricrepository<Deliveryitem>().GetById(basket.DeliveryItemID.Value);
               basket.ShippingCost=deliveryitem.Cost;
                shippingprice = deliveryitem.Cost;
            }
            if (basket?.BasketItems?.Count < 0)
            {
                foreach (var item in basket.BasketItems)
                {
                    var product =await _unitOfWork.CreateGenricrepository<Product>().GetById(item.Id);
                  if(item.Price!=product.Price)
                     item.Price=product.Price;
                }
               
            }
            var service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            

            if (string.IsNullOrEmpty(basket.Paymentintenid))//create paymentintent
            {
                var create = new PaymentIntentCreateOptions()
                {
                    Amount = (long)basket.BasketItems.Sum(item => item.Price * item.Quntity * 100)+(long)shippingprice *100 ,
                    Currency="usd",
                    PaymentMethodTypes=new List<string> { "card"}
                };
                paymentIntent= await service.CreateAsync(create);
                basket.Paymentintenid= paymentIntent.Id;
                basket.ClientSecret= paymentIntent.ClientSecret;

            }
            else //updatepaymentintent
            {
                var update = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)basket.BasketItems.Sum(item => item.Price * item.Quntity * 100) + (long)shippingprice * 100
                };
                await service.UpdateAsync(basketId,update);
            
            }
            await _basketRepository.UpdateBasketAsync(basket);

            return basket;
        }
    }
}
