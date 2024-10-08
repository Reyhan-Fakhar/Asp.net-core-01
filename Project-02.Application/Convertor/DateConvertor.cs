using System.Globalization;

namespace Project_02.Application.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            var calendar = new PersianCalendar();

            return calendar.GetYear(value) + "/"
                                           + calendar.GetMonth(value) + "/"
                                           + calendar.GetDayOfMonth(value)
                                               .ToString("00");
        }
    }
}
