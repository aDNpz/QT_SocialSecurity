using QT12SS.Logic.Entities;

namespace QT12SS.WebApi.Models
{
    public class EditSocialSecurity
    {
        public string SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StateCode State { get; set; }
        public DateTime? BirthDay { get; set; }
        public double? Income { get; set; }
        public string? Note { get; set; }
    }
}
