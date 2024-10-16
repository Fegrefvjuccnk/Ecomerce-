using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Talbat.Core.Entites.orderaggretion;
using Talbat.Repostory.DtoMAPPER;

namespace Talbat.ApIs.Controllers
{
    public class OrderDto
    {
        [Required]
        public string  BasketId { get; set; }

        public int DeliveryItemId { get; set; }

        public AddressDtos shipingaddress { get; set; }

    }
}