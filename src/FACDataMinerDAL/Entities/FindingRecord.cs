using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("findings")]
public class FindingRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string ReportId { get; set; }
    
    [Column("audit_year")]
    public int AuditYear { get; set; }
    
    [Column("auditee_uei")]
    public string AuditeeUEI { get; set; }

    [Column("award_reference")]
    public string? AwardReference { get; set; }

    [Column("reference_number")]
    public string? ReferenceNumber { get; set; }

    [Column("is_material_weakness")]
    public bool IsMaterialWeakness { get; set; }
    
    [Column("is_modified_opinion")]
    public bool IsModifiedOpinion { get; set; }
    
    [Column("is_other_findings")]
    public bool IsOtherFindings { get; set; }

    [Column("is_other_matters")]
    public bool IsOtherMatters { get; set; }
    
    [Column("prior_finding_ref_numbers")]
    public string? PriorFindingRefNumbers { get; set; }

    [Column("is_questioned_costs")]
    public bool IsQuestionedCosts { get; set; }
    
    [Column("is_repeat_finding")]
    public bool IsRepeatFinding { get; set; }
    
    [Column("is_significant_deficiency")]
    public bool IsSignificantDeficiency { get; set; }
    
    [Column("type_requirement")]
    public string? typeRequirement { get; set; }
    
    
    
    public FindingRecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }
}