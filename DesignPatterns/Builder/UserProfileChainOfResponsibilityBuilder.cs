using DesignPatterns.Entities;

namespace DesignPatterns.Builder
{
    public class UserProfileChainOfResponsibilityBuilder : IUserProfileChainOfResponsibilityBuilder
    {
        private UserProfileType Type = UserProfileType.PUBLIC;
        private bool IsActive = true;
        private bool IsLocked = false;
        private DateTime Created;
        private bool EmailNotification;
        public IUserProfileChainOfResponsibilityBuilder Active(bool Active = true)
        {
            IsActive = Active;
            return this;
        }
        public IUserProfileChainOfResponsibilityBuilder Locked(bool locked)
        {
            IsLocked = locked;
            return this;
        }
        public IUserProfileChainOfResponsibilityBuilder NotifyByEmail(bool notify)
        {
            EmailNotification = notify;
            return this;
        }
        public IUserProfileChainOfResponsibilityBuilder IsPrivate(bool isPrivate = true)
        {
            if (isPrivate)
                Type = UserProfileType.PRIVATE;
            else
                Type = UserProfileType.PUBLIC;
            return this;
        }
        public UserProfile Build()
        {
            var userProfile = new UserProfile();
            userProfile.IsActive = IsActive;
            userProfile.Type = Type;
            userProfile.IsLocked = IsLocked;
            userProfile.Created = DateTime.Now;
            userProfile.NotifyByEmail = EmailNotification;
            return userProfile;
        }
    }
}
