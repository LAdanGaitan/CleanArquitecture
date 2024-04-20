namespace CleanArchitecture.Data.Vehicles
{
	public record MoneyType 
	{
		public static readonly MoneyType None = new MoneyType("");
		public static readonly MoneyType Usd = new MoneyType("USD"); 
		public static readonly MoneyType Eur = new MoneyType("EUR");
		private MoneyType(string code) => Code = code;
        public string? Code { get; init; }

		public static readonly IReadOnlyCollection<MoneyType> All = new[]
		{
			Usd,
			Eur
		};

		public static MoneyType FromCode(string code)
		{
			return All.FirstOrDefault(m => m.Code == code)?? 
				throw new ApplicationException("The currency type is invalid");
		}
    };
}
