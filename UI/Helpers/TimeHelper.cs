namespace UI.Helpers;

public static class TimeHelper
{
    private const int Second = 1;
    private const int Minute = 60 * Second;
    private const int Hour = 60 * Minute;
    private const int Day = 24 * Hour;
    private const int Month = 30 * Day;

    public static string Relative(DateTimeOffset t)
    {
        var ts = new TimeSpan(DateTime.UtcNow.Ticks - t.DateTime.Ticks);
        var delta = Math.Abs(ts.TotalSeconds);

        switch (delta)
        {
            case < 1 * Minute:
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            case < 2 * Minute:
                return "a minute ago";
            case < 45 * Minute:
                return ts.Minutes + " minutes ago";
            case < 90 * Minute:
                return "an hour ago";
            case < 24 * Hour:
                return ts.Hours + " hours ago";
            case < 48 * Hour:
                return "yesterday";
            case < 30 * Day:
                return ts.Days + " days ago";
            case < 12 * Month:
            {
                var months = Convert.ToInt32(Math.Floor((double) ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            default:
            {
                var years = Convert.ToInt32(Math.Floor((double) ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}