namespace CleanArchitecture.Domain.Rentals
{
	public sealed record DateRange
	{
        private DateRange()
        {
            
        }

        public DateOnly Init { get; init; }
        public DateOnly End { get; init; }
        public int NumberOfDays => End.DayNumber - Init.DayNumber;

        public static DateRange Create(DateOnly init,DateOnly end)
        {
            if(init> end)
            {
                throw new ApplicationException("La fecha final es anterio a la fecha de inicio");
            }

            return new DateRange
            {
                Init = init,
                End = end
            };
        }
    }
}
