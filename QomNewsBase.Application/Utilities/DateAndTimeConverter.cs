using System.Globalization;

namespace QomNewsBase.Application.Utilities;

public class DateAndTimeConverter
{
    public readonly string[] PersianMonths =
    {
        "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
        "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
    };

    public string ConvertToShamsi(DateTime date)
    {
        PersianCalendar persianCalendar = new PersianCalendar();

        return persianCalendar.GetYear(date) + "/" +
            persianCalendar.GetMonth(date).ToString("00") + "/" +
            persianCalendar.GetDayOfMonth(date).ToString("00");
    }

    public string ConvertToPersianString(DateTime date)
    {
        PersianCalendar persianCalendar = new PersianCalendar();

        int year = persianCalendar.GetYear(date);
        int month = persianCalendar.GetMonth(date);
        int day = persianCalendar.GetDayOfMonth(date);

        return $"{day} {PersianMonths[month - 1]} {year}";
    }
}