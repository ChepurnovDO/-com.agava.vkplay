using System;

[Serializable]
public class VKPlayWebAdsConfig
{
    /// <summary>
    /// "admanSource, admanagerSource" OR
    /// <br/>
    /// "admanSource" OR
    /// <br/>
    /// "admanagerSource" OR
    /// <br/>
    /// nothing (null), the best advertising source will be selected.
    /// </summary>
    public string sources;

    /// <summary>
    /// true - an interstitial video will be shown
    /// <br/>
    /// false - ads will be shown in advideoreward format
    /// </summary>
    public bool Interstitial;
}