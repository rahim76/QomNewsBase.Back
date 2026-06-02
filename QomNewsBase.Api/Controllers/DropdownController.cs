using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QomNewsBase.Domain.Enums;

namespace QomNewsBase.Api.Controllers;

public class DropdownController : BaseController
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAdPositionTypes()
    {
        var model = EnumToSelectList(typeof(AdPositionTypeEnum)).ToList();
        return Ok(model);
    }
}