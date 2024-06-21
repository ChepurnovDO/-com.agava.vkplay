using System;

[Serializable]
public class GetLoginStatusCallbackData : VKPlayWebEventArgsBase
{
    /// <summary>
    /// User status:
    /// <br/>
    /// 0 - user is not authorized;
    /// <br/>
    /// 1 - user is authorized, not registered;
    /// <br/>
    /// 2 - user is authorized, registered;
    /// <br/>
    /// 3 - user is authorized, registered, and has made a game purchase
    /// (only for premium and paid games with in-game transactions support).
    /// </summary>
    public int LoginStatus;
}