using DesignPatterns.Entities;

namespace DesignPatterns.Builder;
public interface IUserProfileBuilder
{
    public void Active(bool Active = true);
    public void Locked(bool locked = true);
    public void NotifyByEmail(bool notify = true);
    public void IsPrivate(bool isPrivate = true);
    public UserProfile Build();
}
