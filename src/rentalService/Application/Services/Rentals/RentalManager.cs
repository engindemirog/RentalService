using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Rentals;

public class RentalManager : IRentalService
{
    private readonly IRentalRepository _rentalRepository;
    private readonly RentalBusinessRules _rentalBusinessRules;

    public RentalManager(IRentalRepository rentalRepository, RentalBusinessRules rentalBusinessRules)
    {
        _rentalRepository = rentalRepository;
        _rentalBusinessRules = rentalBusinessRules;
    }

    public async Task<Rental?> GetAsync(
        Expression<Func<Rental, bool>> predicate,
        Func<IQueryable<Rental>, IIncludableQueryable<Rental, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Rental? rental = await _rentalRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rental;
    }

    public async Task<IPaginate<Rental>?> GetListAsync(
        Expression<Func<Rental, bool>>? predicate = null,
        Func<IQueryable<Rental>, IOrderedQueryable<Rental>>? orderBy = null,
        Func<IQueryable<Rental>, IIncludableQueryable<Rental, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Rental> rentalList = await _rentalRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return rentalList;
    }

    public async Task<Rental> AddAsync(Rental rental)
    {
        Rental addedRental = await _rentalRepository.AddAsync(rental);

        return addedRental;
    }

    public async Task<Rental> UpdateAsync(Rental rental)
    {
        Rental updatedRental = await _rentalRepository.UpdateAsync(rental);

        return updatedRental;
    }

    public async Task<Rental> DeleteAsync(Rental rental, bool permanent = false)
    {
        Rental deletedRental = await _rentalRepository.DeleteAsync(rental);

        return deletedRental;
    }
}
