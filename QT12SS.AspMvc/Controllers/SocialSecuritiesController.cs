using Microsoft.AspNetCore.Mvc;
using QT12SS.Logic;
using QT12SS.Logic.Entities;

namespace QT12SS.AspMvc.Controllers
{
    public class SocialSecuritiesController : GenericController<Logic.Entities.SocialSecurity, Models.SocialSecurity>
    {
        public SocialSecuritiesController(Logic.Controllers.SocialSecuritiesController dataAccess) : base(dataAccess)
        {
        }
    }
}
