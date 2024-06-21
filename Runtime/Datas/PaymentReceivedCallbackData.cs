using System;

[Serializable]
public class PaymentReceivedCallbackData : VKPlayWebEventArgsBase
{
    /// <summary>
    /// User ID on the platform.
    /// </summary>
    public int uid;
}