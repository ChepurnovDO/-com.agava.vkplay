using System;

[Serializable]
public class UserFriendsCallbackData : VKPlayWebEventArgsBase
{
    /// <summary>
    /// Friend list
    /// </summary>
    public UserFriendsCallbackDataFriend[] friends;
}