using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FACDataMiner.Utilities.Extensions;
namespace FACDataMinerDAL.Entities;


[Table("passthroughs")]
public class PassthroughRecord: IBaseFACRecord
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

    [Column("passthrough_id")]
    public string? PassthroughId { get; set; }

    [Column("passthrough_name")]
    public string? PassthroughName { get; set; }

    public PassthroughRecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }

    public PassthroughRecord(IDictionary<string, string> record)
    {
        ReportId = record["report_id"].ToStringOrNullValue();
        AuditeeUEI = record["auditee_uei"].ToStringOrNullValue();
        AuditYear = int.Parse(record["audit_year"]);
        
        
    }
    
}