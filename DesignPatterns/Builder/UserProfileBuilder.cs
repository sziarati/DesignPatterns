using DesignPatterns.Entities;

namespace DesignPatterns.Builder
{
    public class UserProfileBuilder : IUserProfileBuilder
    {
        private UserProfileType Type = UserProfileType.PUBLIC;
        private bool IsActive = true ;
        private bool IsLocked = false;
        private DateTime Created ;
        private bool EmailNotification;
        public void Active(bool Active = true)
        {
            IsActive = Active ;
        }
        public void Locked(bool locked)
        {
            IsLocked = locked;
        }
        public void NotifyByEmail(bool notify)
        {
            EmailNotification = notify;            
        }
        public void IsPrivate(bool isPrivate = true)
        {
            if (isPrivate)
                Type = UserProfileType.PRIVATE;
            else
                Type = UserProfileType.PUBLIC;
        }
        public UserProfile Build()
        {
            var userProfile = new UserProfile();
            userProfile.IsActive = IsActive ;
            userProfile.Type = Type ;
            userProfile.IsLocked = IsLocked ;
            userProfile.Created = DateTime.Now ;
            userProfile.NotifyByEmail = EmailNotification ;
            return userProfile;
        }
    }
}
