namespace FACDataMinerDAL.Entities;

public interface IBaseFACRecord
{
    public string? ReportId { get; set; }
    public int AuditYear { get; set; }
    public string? AuditeeUEI { get; set; }
}