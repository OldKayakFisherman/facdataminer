using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("additional_ueis")]
public class AdditionalUEIRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string? ReportId { get; set; }
    
    [Column("audit_year")]
    public int AuditYear { get; set; }
    
    [Column("auditee_uei")]
    public string? AuditeeUEI { get; set; }

    [Column("additional_uei")]
    public string? AdditionalUEI { get; set; }

    public AdditionalUEIRecord(string reportId, int auditYear, string auditeeUei)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUei;
    }

    public AdditionalUEIRecord()
    {
        AuditYear = DateTime.Now.Year;
    }
}