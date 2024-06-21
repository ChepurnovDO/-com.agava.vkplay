using System;

[Serializable]
public class UserFriendsCallbackDataFriend
{
    /// <summary>
    /// User ID on the platform
    /// </summary>
    public int uid;

    /// <summary>
    /// User nickname;
    /// </summary>
    public string nick;

    /// <summary>
    /// Unique user identifier
    /// </summary>
    public string slug;

    /// <summary>
    /// Link to image for user avatar
    /// </summary>
    public string avatar;
}