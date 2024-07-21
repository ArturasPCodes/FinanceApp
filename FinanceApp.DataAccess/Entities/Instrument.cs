using FinanceApp.Domain.Enums;

namespace FinanceApp.DataAccess.Entities
{
    public class Instrument
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public InstrumentType Type { get; set; }
        public ICollection<Investment>? Investments { get; set; }
    }
}
