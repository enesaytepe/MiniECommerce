namespace Domain.Entities;
public interface ITrackable
{
    public uint RowVersion { get; set; }
    DateTime CreatedDateTime { get; set; }
    DateTime? UpdatedDateTime { get; set; }
}