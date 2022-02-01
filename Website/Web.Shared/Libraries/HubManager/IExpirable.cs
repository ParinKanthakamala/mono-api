using System;

namespace Web.Shared.Libraries.HubManager
{
    public interface IExpirable
    {
        DateTime ExpiresAt { get; }
        bool IsExpired => DateTime.Now > ExpiresAt;
        int ExpiresInMin => (int)Math.Ceiling((decimal)ExpiresInSec / 60);
        int ExpiresInSec => (int)Math.Ceiling(ExpiresAt.Subtract(DateTime.Now).TotalMilliseconds / 1000);
    }
}
