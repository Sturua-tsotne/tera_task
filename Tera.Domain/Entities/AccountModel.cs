namespace Tera.Domain.Entities;

public class AccountModel : BaseEntity
{
    public int UserId { get; set; }
    public decimal Balance { get; set; }

    public string Name { get; set; }

    public virtual UserModel User { get; set; }
}
