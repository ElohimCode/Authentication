using Common.Utils.Enums;

namespace Common.Utils.Tools
{
    public static class DataTimeUtils
    {
        public static DateTime Now() => DateTime.UtcNow;
        public static DateTime AddTime(int time, TimeUnit timeUnit = TimeUnit.Minute)
        {
            DateTime dateTime = Now();
            switch (timeUnit)
            {
                case TimeUnit.Second: dateTime = dateTime.AddSeconds(time); break;
                case TimeUnit.Minute: dateTime = dateTime.AddMinutes(time); break;
                case TimeUnit.Hour: dateTime = dateTime.AddHours(time); break;
                case TimeUnit.Day: dateTime = dateTime.AddDays(time); break;
            }
            return dateTime;
        }
    }
}
