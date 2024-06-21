using System;

[Serializable]
public class UserSocialFriendsCallbackData : VKPlayWebEventArgsBase
{
    /// <summary>
    /// Friend list
    /// </summary>
    public UserSocialFriendsCallbackDataFriend[] friends;
}