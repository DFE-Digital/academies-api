using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Enums;

namespace TramsDataApi.Extensions
{
    public static class ToSurplusDeficit
    {
        public static string ToSurplusDeficitString(this A2BSurplusDeficitEnum? value)
        {
            return value.HasValue? value.ToString() : null;
         
            //return value.HasValue ? Enum.GetName(typeof(A2BSurplusDeficitEnum), value)
            //    : null;
        }

        public static A2BSurplusDeficitEnum ToSurplusDeficitEnum(this string value)
        {
            return Enum.Parse< A2BSurplusDeficitEnum>(value);
        }
    }
}
