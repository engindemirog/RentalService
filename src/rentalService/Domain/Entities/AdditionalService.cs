using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class AdditionalService : Entity<Guid>
{
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }

    public AdditionalService() { }

    public AdditionalService(Guid id, string name, decimal dailyPrice)
        : base(id)
    {
        Name = name;
        DailyPrice = dailyPrice;
    }
}


