using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FACDataMiner.Utilities.Extensions;

namespace FACDataMinerDAL.Entities;

[Table("corrective_action_plans")]
public class CorrectiveActionPlanRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string? ReportId { get; set; }
    
    [Column("audit_year")]
    public int AuditYear { get; set; }
    
    [Column("auditee_uei")]
    public string? AuditeeUEI { get; set; }

    [Column("finding_ref_number")] 
    public string? FindingReferenceNumber { get; set; }

    [Column("contains_chart_or_table")] 
    public bool? ContainsChartsOrTables { get; set; }
    
    [Column("planned_action")] 
    public string? PlannedAction { get; set; }
    

    public CorrectiveActionPlanRecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }

    public CorrectiveActionPlanRecord(IDictionary<string, string> record)
    {
        ReportId = record["report_id"].ToStringOrNullValue();
        AuditeeUEI = record["auditee_uei"].ToStringOrNullValue();
        AuditYear = int.Parse(record["audit_year"]);
        FindingReferenceNumber = record["finding_ref_number"].ToStringOrNullValue();
        ContainsChartsOrTables = record["contains_chart_or_table"].ToBooleanOrNullValue();
        PlannedAction = record["planned_action"].ToStringOrNullValue();
    }
    
    
    
}