using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("awards")]
public class AwardRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string ReportId { get; set; }
    
    [Column("audit_year")]
    public short AuditYear { get; set; }

    [Column("auditee_uei")]
    public string AuditeeUEI { get; set; }
    
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
    public bool IsMajor { get; set; }

    [Column("is_loan")]
    public bool IsLoan { get; set; }
    
    [Column("loan_balance")]
    public string? LoanBalance { get; set; }
    
    [Column("is_direct")]
    public bool IsDirect { get; set; }
    
    [Column("audit_report_type")]
    public string? AuditReportType { get; set; }
    
    [Column("findings_count")]
    public int? FindingsCount { get; set; }
    
    [Column("is_passthrough_award")]
    public bool IsPassthroughAward { get; set; }
    
    [Column("passthrough_amount")]
    public decimal? PassthroughAmount { get; set; }

    
    public AwardRecord(string reportId, short auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }
    
}