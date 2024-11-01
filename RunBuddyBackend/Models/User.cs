namespace RunBuddyBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GoogleId { get; set; }
        public string FacebookId { get; set; }
        public Point Location { get; set; } // PostGIS Point for location
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //constructor to enforce non-nullable values
        public User(int id, string name, string email, string googleId, string facebookId, Point location)
        {
            Id = id;
            Name = name;
            Email = email;
            GoogleId = googleId;
            FacebookId = facebookId;
            Location = location;
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
        }
    }
}
