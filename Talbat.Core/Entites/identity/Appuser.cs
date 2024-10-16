using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talbat.Core.Entites.identity
{
    public class Appuser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address address { get; set; }
    }
}
