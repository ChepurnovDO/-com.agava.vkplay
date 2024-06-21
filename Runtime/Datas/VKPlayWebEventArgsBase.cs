using System;

/// <summary>
/// Базовый класс для коллбеков которые сообщают об ошибках через status или errcode
/// </summary>
[Serializable]
public class VKPlayWebEventArgsBase : EventArgs
{
    /// <summary>
    /// "ok" if the operation is successful.
    /// </summary>
    public string status;

    /// <summary>
    /// Internal partner error code.
    /// </summary>
    public int errcode;

    /// <summary>
    /// Description of partner error code.
    /// </summary>
    public string errmsg;
}