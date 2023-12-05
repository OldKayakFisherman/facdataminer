using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("notes_to_sefa")]
public class NotesToSEFARecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string ReportId { get; set; }
    
    [Column("audit_year")]
    public int AuditYear { get; set; }
    
    [Column("auditee_uei")]
    public string AuditeeUEI { get; set; }
    
    [Column("title")] 
    public string? Title { get; set; }

    [Column("accounting_policies")] 
    public string? AccountingPolicies { get; set; }

    [Column("is_minimis_rate_used")] 
    public bool IsMinimisRateUsed { get; set; }

    [Column("rate_explained")] 
    public string? RateExplained { get; set; }
    
    [Column("contains_chart_or_table")] 
    public bool ContainsChartsOrTables { get; set; }


    public NotesToSEFARecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }
}