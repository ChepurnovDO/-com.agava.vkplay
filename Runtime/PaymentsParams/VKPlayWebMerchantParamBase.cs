using System;

[Serializable]
public class VKPlayWebMerchantParamBase
{
    /// <summary>
    /// amount
    /// </summary>
    public int amount;

    /// <summary>
    /// item description
    /// </summary>
    public string description;

    /// <summary>
    /// Currency, usually "RUB"
    /// </summary>
    public string currency;

    // наследуйте от этого класса чтобы добавить доп. опции...
}