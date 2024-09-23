using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dfe.Academies.Utils.Enums;

namespace Dfe.Academies.Utils.Helpers
{
    public static class IdentifierHelper<TId, TEnum> where TEnum : Enum
    {
        public static TEnum DetermineIdType(TId id, Dictionary<TEnum, Func<TId, bool>> idValidators)
        {
            foreach (var validator in idValidators)
            {
                if (validator.Value(id))
                {
                    return validator.Key;
                }
            }

            return (TEnum)Enum.Parse(typeof(TEnum), "Invalid");
        }

        public static Dictionary<TEnum, Func<TId, bool>> GetDefaultIdValidators()
        {
            throw new NotImplementedException("Please implement this method in your specific use case.");
        }
    }
}
