using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("passthroughs")]
public class PassthroughRecord
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

    [Column("passthrough_id")]
    public string? PassthroughId { get; set; }

    [Column("passthrough_name")]
    public string? PassthroughNamwe { get; set; }

    public PassthroughRecord(string reportId, short auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }   
}