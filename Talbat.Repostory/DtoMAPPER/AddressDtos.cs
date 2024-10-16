using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talbat.Repostory.DtoMAPPER
{
    public class AddressDtos
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        
    }
}
