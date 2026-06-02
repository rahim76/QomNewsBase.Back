using Microsoft.AspNetCore.Mvc;
using QomNewsBase.Application.Common.Results;
using System.ComponentModel.DataAnnotations;

namespace QomNewsBase.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected List<SelectListViewModel<int>> EnumToSelectList(Type? enumType, Enum? selectedItem = null, bool orderBy = true, List<Enum>? ignore = null)
    {
        var items = new List<SelectListViewModel<int>>();
        if (enumType == null)
            return items;

        var values = Enum.GetValues(enumType);
        items.AddRange(from Enum item in values
                       where ignore == null || !ignore.Contains(item)
                       select new SelectListViewModel<int>
                       {
                           Id = Convert.ToInt32(item),
                           Title = GetEnumDisplayValue(item),
                           Selected = selectedItem != null && item.ToString() == selectedItem.ToString()
                       });
        return orderBy
            ? items.OrderBy(item => item.Id)
                .ToList()
            : items.ToList();
    }

    protected string? GetEnumDisplayValue(Enum enumName)
    {
        var type = enumName.GetType();
        var field = type.GetField(enumName.ToString());
        var display = ((DisplayAttribute[])field?.GetCustomAttributes(typeof(DisplayAttribute), false)!).FirstOrDefault();
        return display != null
            ? display.GetName()
            : enumName.ToString();
    }

}