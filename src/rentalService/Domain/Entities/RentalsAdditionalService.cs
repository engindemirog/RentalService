using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class RentalsAdditionalService : Entity<Guid>
{
    public Guid RentalId { get; set; }
    public Guid AdditionalServiceId { get; set; }

    public virtual Rental Rental { get; set; }
    public virtual AdditionalService AdditionalService { get; set; }

    public RentalsAdditionalService() { }

    public RentalsAdditionalService(Guid id, Guid rentalId, Guid additionalServiceId)
        : base(id)
    {
        RentalId = rentalId;
        AdditionalServiceId = additionalServiceId;
    }
}


