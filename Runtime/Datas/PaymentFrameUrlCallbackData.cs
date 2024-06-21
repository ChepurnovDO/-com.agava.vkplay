using System;

[Serializable]
public class PaymentFrameUrlCallbackData : VKPlayWebEventArgsBase
{
    /// <summary>
    /// Link (URL) to the payment frame.
    /// </summary>
    public string url;
}