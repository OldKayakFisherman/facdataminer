using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACDataMinerDAL.Entities;

[Table("secondary_auditors")]
public class SecondaryAuditorRecord: IBaseFACRecord
{
    [Key]
    public int Id { get; set; }

    [Column("report_id")]
    public string ReportId { get; set; }
    
    [Column("audit_year")]
    public int AuditYear { get; set; }

    [Column("auditee_uei")]
    public string AuditeeUEI { get; set; }

    
    [Column("auditor_ein")]
    public string? AuditorEIN { get; set; }
    
    [Column("auditor_name")]
    public string? AuditorName { get; set; }

    [Column("contact_name")]
    public string? ContactName { get; set; }

    [Column("contact_email")]
    public string? ContactEmail { get; set; }

    [Column("contact_phone")]
    public string? ContactPhone { get; set; }

    [Column("address_street")]
    public string? AddressStreet { get; set; }

    [Column("address_city")]
    public string? AddressCity { get; set; }

    [Column("address_state")]
    public string? AddressState { get; set; }
    
    [Column("address_zipcode")]
    public string? AddressZipCode { get; set; }


    
    public SecondaryAuditorRecord(string reportId, int auditYear, string auditeeUEI)
    {
        this.ReportId = reportId;
        this.AuditYear = auditYear;
        this.AuditeeUEI = auditeeUEI;
    }
    
}