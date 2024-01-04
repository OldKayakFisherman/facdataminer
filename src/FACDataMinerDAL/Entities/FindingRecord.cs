using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FACDataMiner.Utilities.Extensions;

namespace FACDataMinerDAL.Entities;

[Table("findings")]
public class FindingRecord: IBaseFACRecord
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

    [Column("reference_number")]
    public string? ReferenceNumber { get; set; }

    [Column("is_material_weakness")]
    public bool? IsMaterialWeakness { get; set; }
    
    [Column("is_modified_opinion")]
    public bool? IsModifiedOpinion { get; set; }
    
    [Column("is_other_findings")]
    public bool? IsOtherFindings { get; set; }

    [Column("is_other_matters")]
    public bool? IsOtherMatters { get; set; }
    
    [Column("prior_finding_ref_numbers")]
    public string? PriorFindingRefNumbers { get; set; }

    [Column("is_questioned_costs")]
    public bool? IsQuestionedCosts { get; set; }
    
    [Column("is_repeat_finding")]
    public bool? IsRepeatFinding { get; set; }
    
    [Column("is_significant_deficiency")]
    public bool? IsSignificantDeficiency { get; set; }
    
    [Column("type_requirement")]
    public string? TypeRequirement { get; set; }
    
    
    
    public FindingRecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }

    public FindingRecord(IDictionary<string, string> record)
    {
        
        ReportId = record["report_id"].ToStringOrNullValue();
        AuditeeUEI = record["auditee_uei"].ToStringOrNullValue();
        AuditYear = int.Parse(record["audit_year"]);
        AwardReference = record["award_reference"].ToStringOrNullValue();
        ReferenceNumber = record["reference_number"].ToStringOrNullValue();
        IsMaterialWeakness = record["is_material_weakness"].ToBooleanOrNullValue();
        IsModifiedOpinion = record["is_modified_opinion"].ToBooleanOrNullValue();
        IsOtherFindings = record["is_other_findings"].ToBooleanOrNullValue();
        IsOtherMatters = record["is_other_matters"].ToBooleanOrNullValue();
        PriorFindingRefNumbers = record["prior_finding_ref_numbers"].ToStringOrNullValue();
        IsQuestionedCosts = record["is_questioned_costs"].ToBooleanOrNullValue();
        IsRepeatFinding = record["is_repeat_finding"].ToBooleanOrNullValue();
        IsSignificantDeficiency = record["is_significant_deficiency"].ToBooleanOrNullValue();
        TypeRequirement = record["type_requirement"].ToStringOrNullValue();
        
    }
    
}