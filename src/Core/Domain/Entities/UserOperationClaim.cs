namespace Domain.Entities;

public class UserOperationClaim : Entity<long>
{
    public long UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }
}