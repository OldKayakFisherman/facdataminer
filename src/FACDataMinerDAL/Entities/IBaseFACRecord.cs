namespace FACDataMinerDAL.Entities;

public interface IBaseFACRecord
{
    public string ReportId { get; set; }
    public short AuditYear { get; set; }
    public string AuditeeUEI { get; set; }
}