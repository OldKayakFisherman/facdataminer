using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FACDataMiner.Utilities.Extensions;

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

    public AdditionalUEIRecord(IDictionary<string, string> value)
    {

        ReportId = value["report_id"].ToStringOrNullValue();
        AuditeeUEI = value["auditee_uei"].ToStringOrNullValue();
        AuditYear = int.Parse(value["audit_year"]);
        AdditionalUEI = value["additional_uei"].ToStringOrNullValue();
        
    }
    
}