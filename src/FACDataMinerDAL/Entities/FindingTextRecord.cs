using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("findings_text")]
public class FindingTextRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string ReportId { get; set; }
    
    [Column("audit_year")]
    public short AuditYear { get; set; }
    
    [Column("auditee_uei")]
    public string AuditeeUEI { get; set; }
    
    [Column("finding_ref_number")] 
    public string? FindingReferenceNumber { get; set; }

    [Column("contains_chart_or_table")] 
    public bool ContainsChartsOrTables { get; set; }
    
    [Column("finding_text")] 
    public string? findingText { get; set; }


    public FindingTextRecord(string reportId, short auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }
}