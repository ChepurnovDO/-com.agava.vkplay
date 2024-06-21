using System;

[Serializable]
public class VKPlayPaymentFrameItemArgs
{
    /// <summary>
    /// List of id like "1,2,3,4"
    /// </summary>
    public string ids;

    public object merchant_param;

    public VKPlayPaymentFrameItemArgs(int[] idsIntArray)
    {
        var s = "";
        for (int i = 0, l = idsIntArray.Length; i < l; ++i)
        {
            s += idsIntArray[i].ToString();
            if (i < l - 1)
            {
                s += ",";
            }
        }

        ids = s;
    }
}