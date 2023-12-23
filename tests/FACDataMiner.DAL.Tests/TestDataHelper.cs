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
    
    public static IList<GeneralRecord> ConstructGeneralRecordsWithAuditYear(int auditYear, int recordCount)
    {
        IList<GeneralRecord> result = new List<GeneralRecord>();

        for (int i = 0; i < recordCount; i++)
        {

            var record = new Faker<GeneralRecord>()
                .CustomInstantiator(f => new GeneralRecord(f.Random.Replace("###-###-#####"),
                    auditYear,
                    f.Random.Replace("#########")))
                .RuleFor(r => r.AuditeeCity, f => f.Address.City())
                .RuleFor(r => r.AuditeeAddressLine1, f => f.Address.StreetAddress())
                .RuleFor(r => r.AuditeeEmail, f => f.Internet.Email())
                .RuleFor(r => r.AuditeeName, f => f.Name.FullName())
                .RuleFor(r => r.AuditeeCertifyName, f => f.Name.FullName())
                .RuleFor(r => r.AuditeeContactName, f => f.Name.FullName())
                .RuleFor(r => r.AuditeeCertifyTitle, f => f.Name.JobTitle())
                .RuleFor(r => r.AuditeeContactTitle, f => f.Name.JobTitle())
                .RuleFor(r => r.AuditeePhone, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.AuditeeState, f => f.Address.State())
                .RuleFor(r => r.AuditeeZip, f => f.Address.State())
                .RuleFor(r => r.AuditType, "single-audit")
                .RuleFor(r => r.CognizantAgency, f => f.PickRandom(TestDataHelper.AgencyIDs()))
                .RuleFor(r => r.DataSource, "gsa-fac")
                .RuleFor(r => r.EntityType, "local")
                .RuleFor(r => r.AuditPeriodCovered, "annual")
                .RuleFor(r => r.AuditorCity, f => f.Address.City())
                .RuleFor(r => r.AuditorCountry, f => f.Address.Country())
                .RuleFor(r => r.AuditorEmail, f => f.Internet.Email())
                .RuleFor(r => r.AuditorPhone, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.AuditorState, f => f.Address.State())
                .RuleFor(r => r.AuditorZip, f => f.Address.ZipCode())
                .RuleFor(r => r.AuditorAddressLine1, f => f.Address.StreetAddress())
                .RuleFor(r => r.AuditorContactName, f => f.Name.FullName())
                .RuleFor(r => r.AuditorContactTitle, f => f.Name.JobTitle())
                .RuleFor(r => r.AuditorFirmName, f => f.Company.CompanyName())
                .RuleFor(r => r.AuditorForeignAddress, f => f.Address.FullAddress())
                .RuleFor(r => r.AuditorEIN, f => f.Random.Replace("############"))
                .RuleFor(r => r.AuditorCertificationDate, f => f.Date.Past())
                .RuleFor(r => r.AuditeeCertificationDate, f => f.Date.Past())
                .RuleFor(r => r.GAAPResults, "not-gaap")
                .RuleFor(r => r.DollarThreshold, f => f.Finance.Amount())
                .RuleFor(r => r.DateCreated, f => f.Date.Past())
                .RuleFor(r => r.AgenciesWithPriorFindings, f => f.PickRandom(TestDataHelper.AgencyIDs()))
                .RuleFor(r => r.AuditorEIN, f => f.Random.Replace("############"))
                .RuleFor(r => r.AuditeeEIN, f => f.Random.Replace("############"))
                .RuleFor(r => r.FACAcceptedDate, f => f.Date.Past())
                .RuleFor(r => r.FYEndDate, f => f.Date.Past())
                .RuleFor(r => r.FYStartDate, f => f.Date.Past())
                .RuleFor(r => r.ReadyForCertificationDate, f => f.Date.Past())
                .RuleFor(r => r.SubmittedDate, f => f.Date.Past())
                .RuleFor(r => r.AuditeeCertificationDate, f => f.Date.Past())
                .RuleFor(r => r.TotalAmountExpended, f => f.Finance.Amount())
                .RuleFor(r => r.TypeAuditCode, "UG")
                .RuleFor(r => r.OversightAgency, f => f.PickRandom(TestDataHelper.AgencyIDs()));
                
            
            result.Add(record);
            
        }

        return result;
    }

    public static IList<AwardRecord> ConstructAwardRecordsWithGeneralRecord(GeneralRecord generalRecord,
        int recordCount)
    {
        IList<AwardRecord> result = new List<AwardRecord>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new Faker<AwardRecord>()
                .CustomInstantiator(f => new AwardRecord(
                    generalRecord.ReportId,
                    generalRecord.AuditYear,
                    generalRecord.AuditeeUEI
                ))
                .RuleFor(r => r.AmountExpended, f => f.Finance.Amount())
                .RuleFor(r => r.AwardReference, f => f.Random.AlphaNumeric(10))
                .RuleFor(r => r.FederalAgencyPrefix, f => f.PickRandom(TestDataHelper.AgencyIDs()))
                .RuleFor(r => r.FederalAgencyExtension, f => f.Random.Replace("###"))
                .RuleFor(r => r.AdditionalAwardIdentification, f => f.Random.AlphaNumeric(10))
                .RuleFor(r => r.FederalProgramName, f => f.Company.CompanyName())
                .RuleFor(r => r.ClusterName, f => f.Company.CompanyName())
                .RuleFor(r => r.OtherClusterName, f => f.Company.CompanyName())
                .RuleFor(r => r.StateClusterName, f => f.Company.CompanyName())
                .RuleFor(r => r.ClusterTotal, f => f.Finance.Amount())
                .RuleFor(r => r.FederalProgramTotal, f => f.Finance.Amount())
                .RuleFor(r => r.LoanBalance, f => f.Finance.Amount())
                .RuleFor(r => r.AuditReportType, "U")
                .RuleFor(r => r.FindingsCount, f => f.Random.Number(0, 100))
                .RuleFor(r => r.PassthroughAmount, f => f.Finance.Amount());
            
            result.Add(record);
        }

        return result;
    }

    
    public static IList<AdditionalUEIRecord> ConstructAdditionalUEIRecordsWithGeneralRecord(GeneralRecord generalRecord,
        int recordCount)
    {
        IList<AdditionalUEIRecord> result = new List<AdditionalUEIRecord>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new Faker<AdditionalUEIRecord>()
                    .CustomInstantiator(f => new AdditionalUEIRecord(
                        generalRecord.ReportId,
                        generalRecord.AuditYear,
                        generalRecord.AuditeeUEI
                    ))
                    .RuleFor(r => r.AdditionalUEI, f => f.Random.Replace("############"));
            
            result.Add(record);

        }

        return result;

    }
    
    public static IList<CorrectiveActionPlanRecord> ConstructCorrectiveActionPlanRecordsWithGeneralRecord(GeneralRecord generalRecord,
        int recordCount)
    {
        IList<CorrectiveActionPlanRecord> result = new List<CorrectiveActionPlanRecord>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new Faker<CorrectiveActionPlanRecord>()
                .CustomInstantiator(f => new CorrectiveActionPlanRecord(
                    generalRecord.ReportId,
                    generalRecord.AuditYear,
                    generalRecord.AuditeeUEI
                ))
                .RuleFor(r => r.PlannedAction, f => f.Random.Words(40))
                .RuleFor(r => r.FindingReferenceNumber, f => f.Random.AlphaNumeric(10));
            
            
            result.Add(record);

        }

        return result;

    }
    
    public static IList<FindingRecord> ConstructFindingRecordsWithGeneralRecord(GeneralRecord generalRecord,
        int recordCount)
    {
        IList<FindingRecord> result = new List<FindingRecord>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new Faker<FindingRecord>()
                .CustomInstantiator(f => new FindingRecord(
                    generalRecord.ReportId,
                    generalRecord.AuditYear,
                    generalRecord.AuditeeUEI
                ))
                .RuleFor(r => r.AwardReference, f => f.Random.AlphaNumeric(10))
                .RuleFor(r => r.ReferenceNumber, f => f.Random.AlphaNumeric(10))
                .RuleFor(r => r.PriorFindingRefNumbers, f => f.Random.AlphaNumeric(10))
                .RuleFor(r => r.AwardReference, "N/A");

            
            
            result.Add(record);

        }

        return result;

    }
    
    public static IList<FindingTextRecord> ConstructFindingTextRecordsWithGeneralRecord(GeneralRecord generalRecord,
        int recordCount)
    {
        IList<FindingTextRecord> result = new List<FindingTextRecord>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new Faker<FindingTextRecord>()
                .CustomInstantiator(f => new FindingTextRecord(
                    generalRecord.ReportId,
                    generalRecord.AuditYear,
                    generalRecord.AuditeeUEI
                ))
                .RuleFor(r => r.FindingReferenceNumber, f => f.Random.AlphaNumeric(10))
                .RuleFor(r => r.findingText, f => f.Random.Words(40));
            
            
            result.Add(record);

        }

        return result;

    }

    public static IList<NotesToSEFARecord> ConstructNotesToSEFARecordsWithGeneralRecord(GeneralRecord generalRecord,
        int recordCount)
    {
        IList<NotesToSEFARecord> result = new List<NotesToSEFARecord>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new Faker<NotesToSEFARecord>()
                .CustomInstantiator(f => new NotesToSEFARecord(
                    generalRecord.ReportId,
                    generalRecord.AuditYear,
                    generalRecord.AuditeeUEI
                ))
                .RuleFor(r => r.Title, f => f.Random.Words(5))
                .RuleFor(r => r.AccountingPolicies, f => f.Random.Words(15))
                .RuleFor(r => r.RateExplained, f => f.Random.Words(20));
            result.Add(record);

        }

        return result;

    }

    public static IList<PassthroughRecord> ConstructPassthroughRecordsWithGeneralRecord(GeneralRecord generalRecord,
        int recordCount)
    {
        IList<PassthroughRecord> result = new List<PassthroughRecord>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new Faker<PassthroughRecord>()
                .CustomInstantiator(f => new PassthroughRecord(
                    generalRecord.ReportId,
                    generalRecord.AuditYear,
                    generalRecord.AuditeeUEI
                ))
                .RuleFor(r => r.AwardReference, f => f.Random.AlphaNumeric(10))
                .RuleFor(r => r.PassthroughId, f => f.Random.AlphaNumeric(10))
                .RuleFor(r => r.PassthroughName, f => f.Random.AlphaNumeric(10));
               
            
            result.Add(record);

        }

        return result;

    }
    
    public static IList<SecondaryAuditorRecord> ConstructSecondaryAuditorRecordsWithGeneralRecord(GeneralRecord generalRecord,
        int recordCount)
    {
        IList<SecondaryAuditorRecord> result = new List<SecondaryAuditorRecord>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new Faker<SecondaryAuditorRecord>()
                .CustomInstantiator(f => new SecondaryAuditorRecord(
                    generalRecord.ReportId,
                    generalRecord.AuditYear,
                    generalRecord.AuditeeUEI
                ))
                .RuleFor(r => r.AuditorEIN, f => f.Random.Replace("############"))
                .RuleFor(r => r.AuditorName, f => f.Name.FullName())
                .RuleFor(r => r.ContactName, f => f.Name.FullName())
                .RuleFor(r => r.ContactEmail, f => f.Internet.Email())
                .RuleFor(r => r.ContactPhone, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.AddressStreet, f => f.Address.StreetAddress())
                .RuleFor(r => r.AddressCity, f => f.Address.City())
                .RuleFor(r => r.AddressState, f => f.Address.StateAbbr())
                .RuleFor(r => r.AddressZipCode, f => f.Address.ZipCode());
            
            result.Add(record);

        }

        return result;
    }
    
}