using Bogus;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var isuredIds = 1;
        var insuredFaker = new Faker<Insured>()
            .RuleFor(i => i.Id, f => isuredIds++)
            .RuleFor(i => i.InsuredName, f => f.Person.FullName)
            .RuleFor(i => i.DateOfBirth, f => f.Person.DateOfBirth)
            .RuleFor(i => i.Gender, f => f.PickRandom<GenderEnum>())
            //.RuleFor(i => i.CardNumber, f => f.Random.AlphaNumeric(16))
            .RuleFor(i => i.CreatedDate, f => f.Date.Past());


        var claimsIds = 1;

        var claimsFaker = new Faker<Claim>()
            .RuleFor(c => c.Id, f => claimsIds++)
            .RuleFor(c => c.CreatedDate, f => f.Date.Past())
            .RuleFor(c => c.AdmissionDate, f => f.Date.Recent())
            .RuleFor(c => c.InsuredId, f => f.Random.Number(min: 1, max: 10))
            .RuleFor(c => c.Hospital, f => f.PickRandom<HospitalsEnum>())
            .RuleFor(c => c.TreatingDoctor, f => f.PickRandom<DoctorsEnum>())
            .RuleFor(c => c.ClaimStatus, f => f.PickRandom<ClaimStatusEnum>())
            .RuleFor(c => c.MedicalCase, f => $"Disease-{claimsIds}")
            .RuleFor(c => c.Amount, f => f.Random.Number(min: 100, max: 10000))
            .RuleFor(c => c.Remarks, f => $"Remark-{claimsIds}");

        var InsuredList = insuredFaker.Generate(10);
        var claimsList = claimsFaker.Generate(100);

        modelBuilder.Entity<Insured>().HasData(InsuredList);
        modelBuilder.Entity<Claim>().HasData(claimsList);
    }
}
