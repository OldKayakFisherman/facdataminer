using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FACDataMiner.Utilities.Extensions;

namespace FACDataMinerDAL.Entities;

[Table("general")]
public class GeneralRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string? ReportId { get; set; }
    
    [Column("audit_year")]
    public int AuditYear { get; set; }

    [Column("auditee_uei")]
    public string? AuditeeUEI { get; set; }

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
    public decimal? TotalAmountExpended { get; set; }

    [Column("type_audit_code")]
    public string? TypeAuditCode { get; set; }
    
    [Column("is_public")]
    public bool IsPublic { get; set; }
    
    [Column("data_source")]
    public string? DataSource { get; set; }
    
    public GeneralRecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }

    public GeneralRecord(IDictionary<string, string> record)
    {

        ReportId = record["report_id"].ToStringOrNullValue();
        AuditeeUEI = record["auditee_uei"].ToStringOrNullValue();
        AuditYear = int.Parse(record["audit_year"]);
        AuditeeCertifyName = record["auditee_certify_name"].ToStringOrNullValue();
        AuditeeCertifyTitle = record["auditee_certify_title"].ToStringOrNullValue();
        AuditeeContactName = record["auditee_contact_name"].ToStringOrNullValue();
        AuditeeEmail = record["auditee_email"].ToStringOrNullValue();
        AuditeeName = record["auditee_name"].ToStringOrNullValue();
        AuditeePhone = record["auditee_phone"].ToStringOrNullValue();
        AuditeeContactTitle = record["auditee_contact_title"].ToStringOrNullValue();
        AuditeeAddressLine1 = record["auditee_address_line_1"].ToStringOrNullValue();
        AuditeeCity = record["auditee_city"].ToStringOrNullValue();
        AuditeeState = record["auditee_state"].ToStringOrNullValue();
        AuditeeEIN = record["auditee_ein"].ToStringOrNullValue();
        AuditeeZip = record["auditee_zip"].ToStringOrNullValue();
        AuditorPhone = record["auditor_phone"].ToStringOrNullValue();
        AuditorState = record["auditor_state"].ToStringOrNullValue();
        AuditorCity = record["auditor_city"].ToStringOrNullValue();
        AuditorContactTitle = record["auditor_contact_title"].ToStringOrNullValue();
        AuditorAddressLine1 = record["auditor_address_line_1"].ToStringOrNullValue();
        AuditorZip = record["auditor_zip"].ToStringOrNullValue();
        AuditorCountry = record["auditor_country"].ToStringOrNullValue();
        AuditorContactName = record["auditor_contact_name"].ToStringOrNullValue();
        AuditorEmail = record["auditor_email"].ToStringOrNullValue();
        AuditorFirmName = record["auditor_firm_name"].ToStringOrNullValue();
        AuditorForeignAddress = record["auditor_foreign_address"].ToStringOrNullValue();
        AuditorEIN = record["auditor_ein"].ToStringOrNullValue();
        CognizantAgency = record["cognizant_agency"].ToStringOrNullValue();
        OversightAgency = record["oversight_agency"].ToStringOrNullValue();
        DateCreated = record["date_created"].ToDateTimeOrNullValue("yyyy-MM-dd");
        ReadyForCertificationDate = record["ready_for_certification_date"].ToDateTimeOrNullValue("yyyy-MM-dd");

        /*
           "auditor_certified_date": "2023-10-19",
           "auditee_certified_date": "2023-10-19",
           "submitted_date": "2023-10-19",
           "fac_accepted_date": "2023-10-19",
           "fy_end_date": "2023-01-01",
           "fy_start_date": "2022-01-01",
           "audit_type": "single-audit",
           "gaap_results": "unmodified_opinion",
           "sp_framework_basis": "",
           "is_sp_framework_required": "",
           "sp_framework_opinions": "",
           "is_going_concern_included": "No",
           "is_internal_control_deficiency_disclosed": "No",
           "is_internal_control_material_weakness_disclosed": "No",
           "is_material_noncompliance_disclosed": "No",
           "dollar_threshold": 750000,
           "is_low_risk_auditee": "Yes",
           "agencies_with_prior_findings": "08",
           "entity_type": "state",
           "number_months": "",
           "audit_period_covered": "annual",
           "total_amount_expended": 2753685,
           "type_audit_code": "UG",
           "is_public": true,
           "data_source": "GSAFAC",
           "is_aicpa_audit_guide_included": "No",
           "is_additional_ueis": "No",
           "is_multiple_eins": "No",
           "is_secondary_auditors": "No"
         */
    }
    
}