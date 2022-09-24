using Microsoft.AspNetCore.Mvc;
using QT12SS.Logic;
using QT12SS.Logic.Entities;

namespace QT12SS.WebApi.Controllers
{
    public class SocialSecuritiesController : GenericController<Logic.Entities.SocialSecurity, Models.EditSocialSecurity, Models.SocialSecurity>
    {
        public SocialSecuritiesController(Logic.Controllers.SocialSecuritiesController dataAccess) : base(dataAccess)
        {
        }

        [HttpGet("Query", Name = nameof(QueryByParamsAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Models.SocialSecurity>>> QueryByParamsAsync(
            [FromQuery(Name = "SocialSecurityNumber")] string? socNr,
            [FromQuery(Name = "FirstName")] string? firstName,
            [FromQuery(Name = "LastName")] string? lastName,
            [FromQuery(Name = "State")] StateCode? state,
            [FromQuery(Name = "Note")] string? note
            )
        {
            using var ctrl = new Logic.Controllers.SocialSecuritiesController();

            if(ctrl == null)
                return Ok(Array.Empty<Models.SocialSecurity>());

            var result = await ctrl.QueryByParamsAsync(socNr, firstName, lastName, state, note);

            return Ok(result.Select(e => ToOutModel(e)));
        }
    }
}
