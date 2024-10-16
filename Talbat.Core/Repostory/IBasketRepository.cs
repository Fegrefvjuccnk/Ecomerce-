using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites;

namespace Talbat.Core.Repostory
{
    public interface IBasketRepository
    {
        Task<BasketCustomer?> GetBasketAsync(string BasketId);
        Task<BasketCustomer?> UpdateBasketAsync(BasketCustomer basketCustomer);
        Task<bool> DeletBasketAstnc(string BasketId);




    }
}
