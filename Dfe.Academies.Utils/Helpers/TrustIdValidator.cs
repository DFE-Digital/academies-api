using Dfe.Academies.Utils.Enums;

namespace Dfe.Academies.Utils.Helpers
{
    public static class TrustIdValidator
    {
        public static Dictionary<TrustIdType, Func<string, bool>> GetTrustIdValidators()
        {
            return new Dictionary<TrustIdType, Func<string, bool>>
            {
                { TrustIdType.Trn, IsValidTrn },
                { TrustIdType.UkPrn, IsValidUkPrn }
            };
        }

        private static bool IsValidTrn(string id)
        {
            return id.StartsWith("TR") && id.Length == 7 && id.Substring(2).All(char.IsDigit);
        }

        private static bool IsValidUkPrn(string id)
        {
            return id.Length == 8 && id.All(char.IsDigit);
        }
    }
}
