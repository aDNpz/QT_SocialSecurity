using QT12SS.Logic.Entities;

namespace QT12SS.AspMvc.Models
{
    public class SocialSecurity : IdentityModel
    {
        [Required]
        [MaxLength(10)]
        public string SocialSecurityNumber { get; set; }
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }

        [Required]
        public StateCode State { get; set; }

        public DateTime? BirthDay { get; set; }
        [Required]
        public DateTime CreationDate { get; internal set; }
        public double? Income { get; set; }
        [MaxLength(1024)]
        public string? Note { get; set; }
    }
}
