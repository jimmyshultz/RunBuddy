using System;

namespace RunBuddyBackend.Models
{
    public class Preference
    {
        public int Id { get; set; }
        
        // Foreign key to the User
        public int UserId { get; set; }
        public User User { get; set; }  // Navigation property

        // Preferred weekly running distance
        public decimal WeeklyDistancePreference { get; set; }

        // Preferred easy run pace (stored as time interval, e.g., minutes per mile/km)
        public TimeSpan EasyRunPacePreference { get; set; }

        // Preferred time(s) to run: Morning, Afternoon, Evening
        public string[] TimePreference { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Set to current time upon creation
        public DateTime UpdatedAt { get; set; } = DateTime.Now; // Will be updated via trigger

        // Constructor to initialize all properties
        public Preference(int userId, User user, decimal weeklyDistancePreference, TimeSpan easyRunPacePreference, string[] timePreference)
        {
            UserId = userId;
            User = user ?? throw new ArgumentNullException(nameof(user)); // Ensure User is not null
            WeeklyDistancePreference = weeklyDistancePreference;
            EasyRunPacePreference = easyRunPacePreference;
            TimePreference = timePreference ?? throw new ArgumentNullException(nameof(timePreference)); // Ensure TimePreference is not null
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
        }
    }
}
