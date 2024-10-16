using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites;

namespace Talbat.Repostory.DtoMAPPER
{
    public class ProductPrifole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctription { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }

        public int ProductBrandId { get; set; }
        public string productBrand { get; set; }
        public string productType { get; set; }
       
    }
}
