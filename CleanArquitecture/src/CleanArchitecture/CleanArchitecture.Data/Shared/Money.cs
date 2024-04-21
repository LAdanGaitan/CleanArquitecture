namespace CleanArchitecture.Domain.Shared
{
    public record Money(decimal Amouth, MoneyType MoneyType)
    {
        public static Money operator +(Money first, Money second)
        {
            if (first.MoneyType != second.MoneyType)
            {
                throw new InvalidOperationException("The currency type must be the same");
            }
            return new Money(first.Amouth + second.Amouth, first.MoneyType);
        }

        public static Money Zero() => new(0, MoneyType.None);
        public static Money Zero(MoneyType moneyType) => new(0, moneyType);
        public bool IsZero() => this == Zero(MoneyType);
    }
}
