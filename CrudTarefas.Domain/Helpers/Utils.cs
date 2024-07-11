namespace CrudTarefas.Domain.Helpers
{
    public static class Utils
    {
        public static DateTime TimeZoneBrasil(this DateTime date)
        {
            var brasil = TimeZoneConverter.TZConvert.GetTimeZoneInfo("E. South America Standard Time");
            return TimeZoneInfo.ConvertTime(date, brasil);
        }
    }
}
