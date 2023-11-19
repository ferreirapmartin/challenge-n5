using System.ComponentModel.DataAnnotations;

namespace ChallengeN5.Distributed.REST.Model
{
    public abstract class PermissionModelBase
    {
        [Required]
        [MaxLength(100)]
        public string Forename { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue)]
        public int? Type { get; set; } = null!;
    }
}
