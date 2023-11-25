namespace FACDataMinerDAL.Entities;

public interface IBaseRecord
{
    public string? ReportId { get; set; }
    public short AuditYear { get; set; }
}