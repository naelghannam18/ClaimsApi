using Core.Services.Contracts;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Implementations;

public class ClaimsService : IClaimsService
{
    private readonly IGenericRepository<Claim> Repo;

    public ClaimsService(IGenericRepository<Claim> repo)
    {
        Repo = repo;
    }

    public async Task<int> CreateClaim(CreateClaimDTO request)
    {
        if (request is null)
        {
            throw new CannotCreateClaimException("Invalid Request Parameters");
        }

        try
        {
            var result = await Repo.Insert(new Claim()
            {
                Amount = request.Amount,
                ClaimStatus = request.ClaimStatus,
                Hospital = request.Hospital,
                InsuredId = request.InsuredId,
                Remarks = request.Remarks,
                TreatingDoctor = request.TreatingDoctor,
                AdmissionDate = request.AdmissionDate,
                MedicalCase = request.MedicalCase,
            });

            return result.Id;
        }
        catch
        {
            throw new CannotCreateClaimException("Error Creating Claim.");
        }
    }

    public async Task<GetClaimDTO> GetClaimById(int id)
    {
        var result = await Repo.GetById(id);
        var claim = result.Include(c => c.Insured).FirstOrDefault();
        if (claim is null) throw new ClaimNotFoundExpection($"Claim with Id {id} not found");
        return Selector().Invoke(claim);
    }

    public async Task<List<GetClaimDTO>> Get(ClaimSearchFilter? filter)
    {
        var claims = await Repo.Get();

        if (filter is not null)
        {

            if (filter.CardNumber is not null)
            {
                claims = claims
                     .Where(c => c.Insured.CardNumber.Equals(filter.CardNumber));
            }

            if (filter.Hospital is not null)
            {
                claims = claims
                    .Where(c => (int)c.Hospital == (int)filter.Hospital);
            }

            if (filter.Range is not null)
            {
                claims = claims
                    .Where(c => c.AdmissionDate >= filter.Range.From && c.AdmissionDate <= filter.Range.To);
            }

            if (filter.ClaimStatus is not null)
            {
                claims = claims
                    .Where(c => (int)c.ClaimStatus == (int)filter.ClaimStatus);
            }
        }

        return claims.Include(c => c.Insured).Select(Selector()).ToList();
    }

    public async Task Update(GetClaimDTO request)
    {
        if (request is null || request.Id is 0)
        {
            throw new ArgumentNullException("Invalid Request");
        }

        var result = await Repo.GetById(request.Id) ?? throw new ClaimNotFoundExpection("Claim Does Not exist");

        var toUpdate = result.First();

        toUpdate.Remarks = request.Remarks;
        toUpdate.ClaimStatus = request.ClaimStatus;
        toUpdate.Amount = request.Amount;
        try
        {
            await Repo.Update(toUpdate);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task Delete(params int[] ids)
    {
        await Repo.Delete(ids);
    }

    private static Func<Claim, GetClaimDTO> Selector()
    {
        return entity => entity == null ? null : new GetClaimDTO()
        {
            Id = entity.Id,
            Amount = entity.Amount,
            ClaimStatus = entity.ClaimStatus,
            Hospital = entity.Hospital,
            Insured = new GetInsuredDTO()
            {
                Id = entity.Insured.Id,
                CardNumber = entity.Insured.CardNumber,
                CreatedDate = entity.Insured.CreatedDate,
                DateOfBirth = entity.Insured.DateOfBirth,
                Gender = entity.Insured.Gender,
                InsuredName = entity.Insured.InsuredName
            },
            InsuredId = entity.Insured.Id,
            Remarks = entity.Remarks,
            TreatingDoctor = entity.TreatingDoctor,
            MedicalCase = entity.MedicalCase,
            AdmissionDate = entity.AdmissionDate
        };
    }
}
