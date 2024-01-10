namespace Tera.Domain.Entities;

public class UserModel : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsEmailConfirmed { get; set; }

    public virtual ICollection<AccountModel> Accounts { get; set; }
}
