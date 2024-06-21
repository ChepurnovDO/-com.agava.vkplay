using System;

[Serializable]
public class GetAuthTokenCallbackData : VKPlayWebEventArgsBase
{
    /// <summary>
    /// User ID on the platform.
    /// </summary>
    public int uid;

    /// <summary>
    /// Authorization token.
    /// </summary>
    public string hash;

    /// <summary>
    /// Full URL of the game.
    /// </summary>
    public string url;
}