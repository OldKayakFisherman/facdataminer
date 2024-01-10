using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FACDataMiner.Utilities.Extensions;

namespace FACDataMinerDAL.Entities;

[Table("findings_text")]
public class FindingTextRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string ReportId { get; set; }
    
    [Column("audit_year")]
    public int AuditYear { get; set; }
    
    [Column("auditee_uei")]
    public string AuditeeUEI { get; set; }
    
    [Column("finding_ref_number")] 
    public string? FindingReferenceNumber { get; set; }

    [Column("contains_chart_or_table")] 
    public bool? ContainsChartsOrTables { get; set; }
    
    [Column("finding_text")] 
    public string? FindingText { get; set; }


    public FindingTextRecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }

    public FindingTextRecord(IDictionary<string, string> record)
    {
        ReportId = record["report_id"].ToStringOrNullValue();
        AuditeeUEI = record["auditee_uei"].ToStringOrNullValue();
        AuditYear = int.Parse(record["audit_year"]);
        FindingReferenceNumber = record["finding_ref_number"].ToStringOrNullValue();
        ContainsChartsOrTables = record["contains_chart_or_table"].ToBooleanOrNullValue();
        FindingText = record["finding_text"].ToStringOrNullValue();
        
    }
}