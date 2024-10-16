using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Talbat.Core.Entites.orderaggretion
{
    public enum OrderStatues
    {
        [EnumMember(Value="pending")]
        pending,
        [EnumMember(Value = "paymentrecived")]
        Paymentrecived,
        [EnumMember(Value = "Paymentfaild")]
        Paymentfaild
    }
}
