using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QT12SS.Logic.Entities
{
    public class SocialSecurity : VersionEntity
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
