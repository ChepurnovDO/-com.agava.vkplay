using System;

/// <summary>
/// This class does not use status to report errors, use code.
/// </summary>
[Serializable]
public class AdsCallbackData : EventArgs
{
    /// <summary>
    /// "adCompleted" - the advertisement has been viewed;
    /// <br/>
    /// "adDismissed" - advertisements are skipped or missing;
    /// <br/>
    /// "adError" - The advertisement was not displayed due to an error.
    /// </summary>
    public string type;

    /// <summary>
    /// "UndefinedAdError" - advertisement display error;
    /// <br/>
    /// "AdblockDetectedAdError" - adblock detected;
    /// <br/>
    /// "WaterfallConfigLoadFailed" - advertisement display error.
    /// </summary>
    public string code;
}