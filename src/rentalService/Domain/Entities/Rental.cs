using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Rental : Entity<Guid>
{
    public Guid CarId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid RentStartRentalBranchId { get; set; }
    public Guid? RentEndRentalBranchId { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }
    public virtual RentalBranch RentStartRentalBranch { get; set; }
    public virtual RentalBranch? RentEndRentalBranch { get; set; }
    public virtual ICollection<RentalsAdditionalService> RentalsAdditionalServices { get; set; }

    public Rental()
    {
        RentalsAdditionalServices = new HashSet<RentalsAdditionalService>();
    }

    public Rental(
        Guid id,
        Guid customerId,
        Guid carId,
        Guid rentStartRentalBranchId,
        Guid rentEndRentalBranchId,
        DateTime rentStartDate,
        DateTime rentEndDate,
        DateTime? returnDate,
        int rentStartKilometer,
        int rentEndKilometer
    )
        : this()
    {
        Id = id;
        CustomerId = customerId;
        CarId = carId;
        RentStartRentalBranchId = rentStartRentalBranchId;
        RentEndRentalBranchId = rentEndRentalBranchId;
        RentStartDate = rentStartDate;
        RentEndDate = rentEndDate;
        ReturnDate = returnDate;
        RentStartKilometer = rentStartKilometer;
        RentEndKilometer = rentEndKilometer;
    }
}


