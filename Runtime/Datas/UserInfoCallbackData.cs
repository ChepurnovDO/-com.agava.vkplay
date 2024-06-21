using System;

[Serializable]
public class UserInfoCallbackData : VKPlayWebEventArgsBase
{
    /// <summary>
    /// User ID on the platform.
    /// </summary>
    public int uid;

    /// <summary>
    /// MD5 hash of the user's email.
    /// </summary>
    public string hash;
}