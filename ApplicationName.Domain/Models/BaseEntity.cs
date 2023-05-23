using System.ComponentModel.DataAnnotations;

namespace ApplicationName.Domain.Models;

public class BaseEntity
{
    [Key] public int Id { get; set; }
}