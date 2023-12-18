namespace App.Wiz.Common.Helper;

// public static class ClockService
// {
//     public static DateTime UtcDateTime { get; } = DateTime.UtcNow;
// }

public interface IDateTimeProvider
{
    DateTime UtcDateTime();
}

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcDateTime()
    {
        return DateTime.UtcNow;
    }
}