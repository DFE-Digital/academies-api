namespace Dfe.Academies.Utils.Helpers
{
    public static class IdentifierHelper<TId, TEnum> where TEnum : Enum
    {
        public static TEnum DetermineIdType(TId id, Dictionary<TEnum, Func<TId, bool>> idValidators)
        {
            var matchingValidator = idValidators.FirstOrDefault(validator => validator.Value(id));

            if (!Equals(matchingValidator, default(KeyValuePair<TEnum, Func<TId, bool>>)))
            {
                return matchingValidator.Key;
            }

            return (TEnum)Enum.Parse(typeof(TEnum), "Invalid");
        }

        public static Dictionary<TEnum, Func<TId, bool>> GetDefaultIdValidators()
        {
            throw new NotImplementedException("Please implement this method in your specific use case.");
        }
    }
}
