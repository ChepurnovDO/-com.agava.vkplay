using System;

[Serializable]
public class UserProfileCallbackData : VKPlayWebEventArgsBase
{
    /// <summary>
    /// User ID on the platform.
    /// </summary>
    public int uid;

    /// <summary>
    /// User nickname;
    /// </summary>
    public string nick;

    /// <summary>
    /// Link (URL) to the image for the user's avatar;
    /// </summary>
    public string avatar;

    /// <summary>
    /// User's year of birth;
    /// </summary>
    public int birthyear;

    /// <summary>
    /// User gender, "male" or "female";
    /// </summary>
    public string sex;

    /// <summary>
    /// Unique string identifier of the user.
    /// </summary>
    public string slug;
}