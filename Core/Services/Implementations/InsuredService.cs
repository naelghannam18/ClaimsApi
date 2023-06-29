using Core.Services.Contracts;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models;
using Infrastructure.Repository;

namespace Core.Services.Implementations;


public class InsuredService : IInsuredService
{
    private readonly IGenericRepository<Insured> Repo;

    public InsuredService(IGenericRepository<Insured> repo)
    {
        Repo = repo;
    }

    public async Task<GetInsuredDTO?> GetInsuredByCardNumber(string cardNumber)
        => (await Repo.Get())
        .Where(i => i.CardNumber.Equals(cardNumber))
        .Select(Selector())
        .FirstOrDefault() ?? throw new InsuredNotFoundException($"Insured with card {cardNumber} Not Found");

    public async Task<GetInsuredDTO?> GetInsuredById(int id)
        => Selector()
        .Invoke((await Repo.GetById(id)).FirstOrDefault())
         ?? 
         throw new InsuredNotFoundException($"Insured with Id {id} Not Found.");

    private static Func<Insured, GetInsuredDTO> Selector()
    {
        return entity => entity == null ? null : new GetInsuredDTO()
        {
            CardNumber = entity.CardNumber,
            CreatedDate = entity.CreatedDate,
            DateOfBirth = entity.DateOfBirth,
            Gender = entity.Gender,
            Id = entity.Id,
            InsuredName = entity.InsuredName
        };
    }
}
