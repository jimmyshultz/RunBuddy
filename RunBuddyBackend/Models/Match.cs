using System;

namespace RunBuddyBackend.Models
{
    public class Match
    {
        public int Id { get; set; }
        
        // Foreign key to User1 (one runner)
        public int User1Id { get; set; }
        public User User1 { get; set; }  // Navigation property for User1

        // Foreign key to User2 (another runner)
        public int User2Id { get; set; }
        public User User2 { get; set; }  // Navigation property for User2

        // Status of the match: pending, accepted, rejected
        public string Status { get; set; } = "pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Set to current time upon creation

        // Constructor to initialize all properties
        public Match(int user1Id, User user1, int user2Id, User user2, string status = "pending")
        {
            User1Id = user1Id;
            User1 = user1;
            User2Id = user2Id;
            User2 = user2;
            Status = status;
            CreatedAt = DateTime.Now;
        }
    }
}
