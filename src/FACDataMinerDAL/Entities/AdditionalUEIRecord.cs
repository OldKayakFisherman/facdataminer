using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("additional_ueis")]
public class AdditionalUEIRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string ReportId { get; set; }
    
    [Column("audit_year")]
    public short AuditYear { get; set; }
    
    [Column("auditee_uei")]
    // ReSharper disable once InconsistentNaming
    public string? AuditeeUEI { get; set; }

    [Column("additional_uei")]
    // ReSharper disable once InconsistentNaming
    public string? AdditionalUEI { get; set; }

    public AdditionalUEIRecord(string reportId, short auditYear)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
    }
    
}