using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites.identity;

namespace Talbat.Repostory.Data.identitydata
{
    public static class Appidentitysedeeing
    {
        public static async Task addappidentityseddingdata(UserManager<Appuser> userManager)
        {
            var user = new Appuser()
            {
                DisplayName = "ebrahem elgharib",
                Email = "EbrahemElghrib@Gamil.com",
                UserName = "ebrahemelgharib",
            };
            await userManager.CreateAsync(user, "Pa$$w0rd");


        }

        //public static async Task addappidentityaddress(Address Address,DbContext dbContext)
        //{
        //    var address = new Address()
        //    {
        //        FirstName = "Ebrahem",
        //        LastName = "Elgharib",
        //        street = "28th",
        //        City = "Elmansoura",
        //        Country="Egypt",
        //        AppuserId= "e7e08c27-8964-4e2e-94ae-b36e98f588c5",
        //    };
        //await dbContext.SaveChangesAsync();
        //}

    }
}
