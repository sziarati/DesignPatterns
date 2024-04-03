using DesignPatterns.Entities;

namespace DesignPatterns.Builder
{
    public class UserProfileBuilder : IUserProfileBuilder
    {
        private UserProfileType _type = UserProfileType.PUBLIC;
        private bool _isActive = true ;
        private bool _isLocked = false;
        private DateTime _created ;
        private bool _emailNotification;
        public UserProfileBuilder()
        {
            _created = DateTime.Now;
        }
        public void Active(bool Active = true)
        {
            _isActive = Active ;
        }
        public void Locked(bool locked)
        {
            _isLocked = locked;
        }
        public void NotifyByEmail(bool notify)
        {
            _emailNotification = notify;            
        }
        public void IsPrivate(bool isPrivate = true)
        {
            _type = isPrivate ? UserProfileType.PRIVATE : UserProfileType.PUBLIC;
        }
        public UserProfile Build()
        {
            var userProfile = new UserProfile()
            {
                IsLocked = _isLocked,
                IsActive = _isActive,
                NotifyByEmail = _emailNotification,
                Type = _type,
                Created = _created,
            };

            return userProfile;
        }
    }
}
