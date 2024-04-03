using DesignPatterns.Entities;

namespace DesignPatterns.Builder
{
    public class UserProfileChainOfResponsibilityBuilder : IUserProfileChainOfResponsibilityBuilder
    {
        private UserProfileType _type = UserProfileType.PUBLIC;
        private bool _isActive = true;
        private bool _isLocked = false;
        private DateTime _created;
        private bool _emailNotification;
        public UserProfileChainOfResponsibilityBuilder()
        {
            _created = DateTime.Now;
        }
        public IUserProfileChainOfResponsibilityBuilder Active(bool Active = true)
        {
            _isActive = Active;
            return this;
        }
        public IUserProfileChainOfResponsibilityBuilder Locked(bool locked)
        {
            _isLocked = locked;
            return this;
        }
        public IUserProfileChainOfResponsibilityBuilder NotifyByEmail(bool notify)
        {
            _emailNotification = notify;
            return this;
        }
        public IUserProfileChainOfResponsibilityBuilder IsPrivate(bool isPrivate = true)
        {
            _type = isPrivate ? UserProfileType.PRIVATE : UserProfileType.PUBLIC;
            return this;
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
