using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class RentalBranch : Entity<Guid>
{
    public City City { get; set; }
    public RentalBranch()
    {
    }

    public RentalBranch(Guid id, City city)
        : this()
    {
        Id = id;
        City = city;
    }
}


