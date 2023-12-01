using FACDataMinerDAL.Entities;

using Bogus;

namespace FACDataMinderDAL.Tests;

public class TestDataHelper
{

    public static IList<string> AgencyIDs()
    {
        IList<string> result = new List<string>();

        for (int i = 1; i <= 99; i++)
        {
            if (i < 10)
            {
                result.Add($"0{i}");
            }
            else
            {
                result.Add($"{i}");
            }
        }
        
        return result;
    }
    
    public static IList<GeneralRecord> ConstructGeneralRecordsWithAuditYear(short auditYear, int amount)
    {
        IList<GeneralRecord> result = new List<GeneralRecord>();

        for (int i = 0; i < amount; i++)
        {

            var record = new Faker<GeneralRecord>()
                .CustomInstantiator(f => new GeneralRecord(f.Random.Replace("###-###-#####"),
                    auditYear,
                    f.Random.Replace("#########")))
                .RuleFor(g => g.AuditeeCity, f => f.Address.City())
                .RuleFor(g => g.AuditeeEmail, f => f.Internet.Email())
                .RuleFor(g => g.AuditeeName, f => f.Name.FullName())
                .RuleFor(g => g.AuditeePhone, f => f.Phone.PhoneNumber())
                .RuleFor(g => g.AuditeeState, f => f.Address.State())
                .RuleFor(g => g.AuditeeZip, f => f.Address.State())
                .RuleFor(g => g.AuditType, "single-audit")
                .RuleFor(g => g.CognizantAgency, f => f.PickRandom(TestDataHelper.AgencyIDs()))
                .RuleFor(g => g.DataSource, "gsa-fac")
                .RuleFor(g => g.EntityType, "local")
                .RuleFor(g => g.AuditorCity, f => f.Address.City())
                .RuleFor(g => g.AuditorCountry, f => f.Address.Country())
                .RuleFor(g => g.AuditorEmail, f => f.Internet.Email())
                .RuleFor(g => g.AuditorPhone, f => f.Phone.PhoneNumber())
                .RuleFor(g => g.AuditorState, f => f.Address.State())
                .RuleFor(g => g.AuditorZip, f => f.Address.ZipCode())
                .RuleFor(g => g.AuditorAddressLine1, f => f.Address.StreetAddress())
                .RuleFor(g => g.AuditorContactName, f => f.Name.FullName())
                .RuleFor(g => g.AuditorContactTitle, f => f.Name.JobTitle())
                .RuleFor(g => g.AuditorFirmName, f => f.Company.CompanyName())
                .RuleFor(g => g.AuditorForeignAddress, f => f.Address.FullAddress())
                .RuleFor(g => g.AuditorEIN, f => f.Random.String(12, 12))
                .RuleFor(g => g.AuditorCertificationDate, f => f.Date.Past())
                .RuleFor(g => g.GAAPResults, "not-gaap")
                .RuleFor(g => g.DollarThreshold, f => f.Finance.Amount());

            result.Add(record);
            
        }

        return result;
    }
}