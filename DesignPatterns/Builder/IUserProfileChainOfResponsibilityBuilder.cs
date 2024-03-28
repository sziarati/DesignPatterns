using DesignPatterns.Entities;

namespace DesignPatterns.Builder;

public interface IUserProfileChainOfResponsibilityBuilder
{
    public IUserProfileChainOfResponsibilityBuilder Active(bool Active = true);
    public IUserProfileChainOfResponsibilityBuilder Locked(bool locked = true);
    public IUserProfileChainOfResponsibilityBuilder NotifyByEmail(bool notify = true);
    public IUserProfileChainOfResponsibilityBuilder IsPrivate(bool isPrivate = true);
    public UserProfile Build();
}
