using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talbat.Core.Entites
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Desctription { get; set; }
        
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
       
        public int ProductBrandId { get; set; }
        public ProductBrand productBrand { get; set; }
        public ProductType productType{ get; set; }

    }
}
