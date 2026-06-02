using System.ComponentModel.DataAnnotations;

namespace QomNewsBase.Domain.Enums;

public enum AdPositionTypeEnum
{
    [Display(Name = "بالای صفحه اصلی")]
    HomeTop = 10,

    [Display(Name = "ساید بار راست")]
    SidebarRight = 20,

    [Display(Name = "ساید بار چپ")]
    SidebarLeft = 30,

    [Display(Name = "وسط خبر")]
    NewsMiddle = 40,

    [Display(Name = "پایین خبر")]
    NewsBottom = 50
}