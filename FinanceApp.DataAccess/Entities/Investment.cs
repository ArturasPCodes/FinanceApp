using FinanceApp.Domain.Enums;

namespace FinanceApp.DataAccess.Entities
{
    public class Investment
    {
        public Guid Id { get; set; }
        public Guid InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        public decimal NumberOfShares { get; set; }
        public decimal PricePerShare { get; set; }
        public DateTime InvestmentDate { get; set; }
        public Currency Currency { get; set; }
    }
}
