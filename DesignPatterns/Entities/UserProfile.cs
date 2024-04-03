namespace DesignPatterns.Entities
{
    public class UserProfile
    {
        public UserProfileType Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime Created { get; set; }
        public bool NotifyByEmail { get; set; }
    }
}
