using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FACDataMiner.Utilities.Extensions;

namespace FACDataMinerDAL.Entities;

[Table("awards")]
public class AwardRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string? ReportId { get; set; }
    
    [Column("audit_year")]
    public int AuditYear { get; set; }

    [Column("auditee_uei")]
    public string? AuditeeUEI { get; set; }
    
    [Column("award_reference")]
    public string? AwardReference { get; set; }

    [Column("federal_agency_prefix")]
    public string? FederalAgencyPrefix { get; set; }
    
    [Column("federal_agency_extension")]
    public string? FederalAgencyExtension { get; set; }
    
    [Column("additional_award_identification")]
    public string? AdditionalAwardIdentification { get; set; }
    
    [Column("federal_program_name")]
    public string? FederalProgramName { get; set; }
    
    [Column("amount_expended")]
    public decimal? AmountExpended { get; set; }

    [Column("cluster_name")]
    public string? ClusterName { get; set; }
    
    [Column("other_cluster_name")]
    public string? OtherClusterName { get; set; }
    
    [Column("state_cluster_name")]
    public string? StateClusterName { get; set; }

    [Column("cluster_total")]
    public decimal? ClusterTotal { get; set; }
    
    [Column("federal_program_total")]
    public decimal? FederalProgramTotal { get; set; }
    
    [Column("is_major")]
    public bool? IsMajor { get; set; }

    [Column("is_loan")]
    public bool? IsLoan { get; set; }
    
    [Column("loan_balance")]
    public decimal? LoanBalance { get; set; }
    
    [Column("is_direct")]
    public bool? IsDirect { get; set; }
    
    [Column("audit_report_type")]
    public string? AuditReportType { get; set; }
    
    [Column("findings_count")]
    public int? FindingsCount { get; set; }
    
    [Column("is_passthrough_award")]
    public bool? IsPassthroughAward { get; set; }
    
    [Column("passthrough_amount")]
    public decimal? PassthroughAmount { get; set; }

    
    public AwardRecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }

    public AwardRecord(IDictionary<string, string> record)
    {
        ReportId = record["report_id"].ToStringOrNullValue();
        AuditeeUEI = record["auditee_uei"].ToStringOrNullValue();
        AuditYear = int.Parse(record["audit_year"]);
        AwardReference = record["award_reference"].ToStringOrNullValue();
        FederalAgencyPrefix = record["federal_agency_prefix"].ToStringOrNullValue();
        FederalAgencyExtension = record["federal_award_extension"].ToStringOrNullValue();
        AdditionalAwardIdentification = record["additional_award_identification"].ToStringOrNullValue();
        FederalProgramName = record["federal_program_name"].ToStringOrNullValue();
        AmountExpended = record["amount_expended"].ToDecimalOrNullValue();
        ClusterName = record["cluster_name"].ToStringOrNullValue();
        OtherClusterName = record["other_cluster_name"].ToStringOrNullValue();
        StateClusterName = record["state_cluster_name"].ToStringOrNullValue();
        ClusterTotal = record["cluster_total"].ToDecimalOrNullValue();
        FederalProgramTotal= record["federal_program_total"].ToDecimalOrNullValue();
        IsMajor = record["is_major"].ToBooleanOrNullValue();
        IsLoan = record["is_loan"].ToBooleanOrNullValue();
        LoanBalance = record["loan_balance"].ToDecimalOrNullValue();
        IsLoan = record["is_direct"].ToBooleanOrNullValue();
        AuditReportType = record["audit_report_type"].ToStringOrNullValue();
        FindingsCount = record["findings_count"].ToIntOrNullValue();
        IsPassthroughAward = record["is_major"].ToBooleanOrNullValue();
        PassthroughAmount = record["passthrough_amount"].ToDecimalOrNullValue();
       
        
    }
    
}