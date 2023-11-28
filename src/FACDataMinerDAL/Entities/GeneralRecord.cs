using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("general")]
public class GeneralRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string ReportId { get; set; }
    
    [Column("audit_year")]
    public short AuditYear { get; set; }

    [Column("auditee_uei")]
    public string AuditeeUEI { get; set; }

    [Column("auditee_certify_name")]
    public string? AuditeeCertifyName { get; set; }
    
    [Column("auditee_certify_title")]
    public string? AuditeeCertifyTitle { get; set; }
    
    [Column("auditee_contact_name")]
    public string? AuditeeContactName { get; set; }
    
    [Column("auditee_email")]
    public string? AuditeeEmail { get; set; }
    
    [Column("auditee_name")]
    public string? AuditeeName { get; set; }
    
    [Column("auditee_phone")]
    public string? AuditeePhone { get; set; }
    
    [Column("auditee_contact_title")]
    public string? AuditeeContactTitle { get; set; }

    [Column("auditee_address_line_1")]
    public string? AuditeeAddressLine1 { get; set; }

    [Column("auditee_city")]
    public string? AuditeeCity { get; set; }
    
    [Column("auditee_state")]
    public string? AuditeeState { get; set; }
    
    [Column("auditee_ein")]
    public string? AuditeeEIN { get; set; }
    
    [Column("auditee_zip")]
    public string? AuditeeZip { get; set; }

    [Column("auditor_phone")]
    public string? AuditorPhone { get; set; }

    [Column("auditor_state")]
    public string? AuditorState { get; set; }
    
    [Column("auditor_city")]
    public string? AuditorCity { get; set; }
    
    [Column("auditor_contact_title")]
    public string? AuditorContactTitle { get; set; }
    
    [Column("auditor_address_line_1")]
    public string? AuditorAddressLine1 { get; set; }
    
    [Column("auditor_zip")]
    public string? AuditorZip { get; set; }
    
    [Column("auditor_country")]
    public string? AuditorCountry { get; set; }
    
    [Column("auditor_contact_name")]
    public string? AuditorContactName { get; set; }
    
    [Column("auditor_email")]
    public string? AuditorEmail { get; set; }

    [Column("auditor_firm_name")]
    public string? AuditorFirmName { get; set; }
    
    [Column("auditor_foreign_address")]
    public string? AuditorForeignAddress { get; set; }
    
    [Column("auditor_ein")]
    // ReSharper disable once InconsistentNaming
    public string? AuditorEIN { get; set; }
    
    [Column("cognizant_agency")]
    public string? CognizantAgency { get; set; }

    [Column("oversight_agency")]
    public string? OversightAgency { get; set; }

    [Column("date_created")]
    public DateTime? DateCreated { get; set; }
   
    [Column("ready_for_certification_date")]
    public DateTime? ReadyForCertificationDate { get; set; }
    
    [Column("auditee_certification_date")]
    public DateTime? AuditeeCertificationDate { get; set; }
    
    [Column("auditor_certification_date")]
    public DateTime? AuditorCertificationDate { get; set; }
    
    [Column("submitted_date")]
    public DateTime? SubmittedDate { get; set; }

    [Column("fac_accepted_date")]
    public DateTime? FACAcceptedDate { get; set; }

    [Column("fy_end_date")]
    public DateTime? FYEndDate { get; set; }
    
    [Column("fy_start_date")]
    public DateTime? FYStartDate { get; set; }

    [Column("audit_type")]
    public string? AuditType { get; set; }

    [Column("gaap_results")]
    // ReSharper disable once InconsistentNaming
    public string? GAAPResults { get; set; }
    
    [Column("sp_framework_basis")]
    public string? SpecialFrameworkBasis { get; set; }
    
    [Column("is_sp_framework_required")]
    public bool IsSpecialFrameworkRequired { get; set; }

    [Column("sp_framework_opinions")]
    public string? SpecialFrameworkOpinions { get; set; }

    [Column("is_going_concern_included")]
    public bool IsGoingConcernIncluded { get; set; }

    [Column("is_internal_control_deficiency_disclosed")]
    public bool IsInternalControlDeficiencyDisclosed { get; set; }

    [Column("is_internal_material_weakness_disclosed")]
    public bool IsInternalMaterialWeaknessDisclosed { get; set; }

    [Column("is_internal_material_noncompliance_disclosed")]
    public bool IsInternalMaterialNonComplianceDisclosed { get; set; }
    
    [Column("dollar_threshold")]
    public decimal? DollarThreshold { get; set; }
    
    [Column("is_low_risk_auditee")]
    public bool IsLowRiskAuditee { get; set; }
    
    [Column("agencies_with_prior_findings")]
    public string? AgenciesWithPriorFindings { get; set; }
    
    [Column("entity_type")]
    public string? EntityType { get; set; }
    
    [Column("number_months")]
    public short NumberOfMonths { get; set; }
    
    [Column("audit_period_covered")]
    public string? AuditPeriodCovered { get; set; }
    
    [Column("total_amount_expended")]
    public string? TotalAmountExpended { get; set; }

    [Column("type_audit_code")]
    public string? TypeAuditCode { get; set; }
    
    [Column("is_public")]
    public bool IsPublic { get; set; }
    
    [Column("data_source")]
    public string? DataSource { get; set; }
    
    public GeneralRecord(string reportId, short auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }
    
}