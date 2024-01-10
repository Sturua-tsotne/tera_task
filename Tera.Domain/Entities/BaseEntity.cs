using System.ComponentModel.DataAnnotations;

namespace Tera.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
