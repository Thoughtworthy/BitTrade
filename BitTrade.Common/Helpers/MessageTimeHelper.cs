using System;

namespace BitTrade.Common.Helpers
{
    public static class MessageTimeHelper 
    {

        public static string FormatTimeDifference(DateTime startTime)
        {
            TimeSpan timeDifference = DateTime.Now.AddHours(-4) - startTime;

            if (timeDifference.TotalDays >= 1)
            {
                int days = (int)timeDifference.TotalDays;
                return days == 1 ? "1 day ago" : $"{days} days ago";
            }
            else if (timeDifference.TotalHours >= 1)
            {
                int hours = (int)timeDifference.TotalHours;
                return hours == 1 ? "1 hour ago" : $"{hours} hours ago";
            }
            else if (timeDifference.TotalMinutes >= 1)
            {
                int minutes = (int)timeDifference.TotalMinutes;
                return minutes == 1 ? "1 minute ago" : $"{minutes} minutes ago";
            }
            else if (timeDifference.TotalSeconds >= 1)
            {
                int seconds = (int)timeDifference.TotalSeconds;
                return seconds == 1 ? "1 second ago" : $"{seconds} seconds ago";
            }
            else
            {
                return "Just now";
            }
        }
    }
}
