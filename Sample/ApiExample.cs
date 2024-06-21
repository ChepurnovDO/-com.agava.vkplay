using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ApiExample : MonoBehaviour
{
    [SerializeField] private int _gmrId;
    
    private VKPlayWeb _vKPlay;
    private GetLoginStatusCallbackData _loginStatusData;
    
    private void Start()
    {
        _vKPlay = VKPlayWeb.Instance;

        _vKPlay.AdsCallback += OnAdsCallback;
        _vKPlay.UserInfoCallback += OnUserInfoCallback;
        _vKPlay.UserProfileCallback += OnUserProfileCallback;
        _vKPlay.UserFriendsCallback += OnUserFriendsCallback;
        _vKPlay.GetAuthTokenCallback += OnGetAuthTokenCallback;
        _vKPlay.RegisterUserCallback += OnRegisterUserCallback;
        _vKPlay.GetLoginStatusCallback += OnGetLoginStatusCallback;
        _vKPlay.PaymentReceivedCallback += OnPaymentReceivedCallback;
        _vKPlay.PaymentFrameUrlCallback += OnPaymentFrameUrlCallback;
        _vKPlay.PaymentWindowClosedCallback += OnPaymentWindowClosedCallback;
        _vKPlay.UserSocialFriendsCallback += OnUserSocialFriendsCallback;
        _vKPlay.ConfirmWindowClosedCallback += OnConfirmWindowClosedCallback;
        
        _vKPlay.Initialize(_gmrId, () => Debug.Log("OnSuccessCallback"));
    }
    
    private void OnDisable()
    {
        _vKPlay.AdsCallback -= OnAdsCallback;
        _vKPlay.UserInfoCallback -= OnUserInfoCallback;
        _vKPlay.UserProfileCallback -= OnUserProfileCallback;
        _vKPlay.UserFriendsCallback -= OnUserFriendsCallback;
        _vKPlay.GetAuthTokenCallback -= OnGetAuthTokenCallback;
        _vKPlay.RegisterUserCallback -= OnRegisterUserCallback;
        _vKPlay.GetLoginStatusCallback -= OnGetLoginStatusCallback;
        _vKPlay.PaymentReceivedCallback -= OnPaymentReceivedCallback;
        _vKPlay.PaymentFrameUrlCallback -= OnPaymentFrameUrlCallback;
        _vKPlay.PaymentWindowClosedCallback -= OnPaymentWindowClosedCallback;
        _vKPlay.UserSocialFriendsCallback -= OnUserSocialFriendsCallback;
        _vKPlay.ConfirmWindowClosedCallback -= OnConfirmWindowClosedCallback;

    }
    
    public void GetInitStatus() => Debug.Log(_vKPlay.GetIsInitialized());

    #region UserAndSocial
    
    public void AuthUser()
    {
        if (_loginStatusData.LoginStatus == 0)
            _vKPlay.AuthorizeUser();
        else
            Debug.Log($"User authorized already");
    }
    
    public void RegisterUser() => _vKPlay.registerUser();
    public void RequestUserInfo() => _vKPlay.GetUserInfo();
    public void RequestUserFriends() => _vKPlay.GetUserFriends();
    public void RequestUserProfile() => _vKPlay.GetUserProfile();
    public void GetAuthToken() => _vKPlay.GetAuthorizationToken();
    public void GetUserLoginStatus() => _vKPlay.GetUserLoginStatus();
    public void RequestUserSocialFriends() => _vKPlay.GetUserSocialFriends();
    #endregion

    #region Advertisement

    public void ShowRewardAd()
    {
        VKPlayWebAdsConfig adsConfig = new()
        {
            Interstitial = false
        };

        _vKPlay.ShowAd(adsConfig);
    
    }

    public void ShowInterstitialAd()
    {
        VKPlayWebAdsConfig adsConfig = new()
        {
            Interstitial = true
        };

        _vKPlay.ShowAd(adsConfig);
    }
    
    #endregion

    #region Payment //InDevelop//

    public void GetPaymentFrameItem(VKPlayPaymentFrameItemArgs paymentFrameItemArgs) => 
        _vKPlay.GetPaymentFrameItem(paymentFrameItemArgs);

    public void GeneratePaymentFrameUrl(VKPlayPaymentFrameArgs paymentFrameArgs) => 
        _vKPlay.GeneratePaymentFrameUrl(paymentFrameArgs);

    public void ShowPaymentForm(VKPlayPaymentFrameArgs paymentFrameArgs) => 
        _vKPlay.ShowPaymentForm(paymentFrameArgs);

    public void GetInGameInventoryItems() => 
        _vKPlay.GetInGameInventoryItems();

    #endregion
    
    
    #region Callbacks

    #region UserAndSocial_Callbacks

    private void OnGetAuthTokenCallback(object sender, GetAuthTokenCallbackData authTokenData)
    {
        if (authTokenData.status == "ok")
            Debug.Log($"token data, uid={authTokenData.uid}, token={authTokenData.hash}");
        else
            Debug.Log($"Error code: {authTokenData.errcode}, Error message: {authTokenData.errmsg}");
    }
    
    private void OnUserInfoCallback(object sender, UserInfoCallbackData userInfoData)
    {
        if (userInfoData.status == "ok")
            Debug.Log($"uid={userInfoData.uid}, hash={userInfoData.hash}");
    }

    private void OnUserProfileCallback(object sender, UserProfileCallbackData userProfileData)
    {
        if (userProfileData.status == "ok")
        {
            Debug.Log($"{nameof(userProfileData.uid)}  {userProfileData.uid}!");
            Debug.Log($"{nameof(userProfileData.sex)}  {userProfileData.sex}!");
            Debug.Log($"{nameof(userProfileData.nick)}  {userProfileData.nick}!");
            Debug.Log($"{nameof(userProfileData.slug)}  {userProfileData.slug}!");
            Debug.Log($"{nameof(userProfileData.birthyear)} {userProfileData.birthyear}!");
        }
    }

    private void OnUserFriendsCallback(object sender, UserFriendsCallbackData userFriendsData)
    {
        foreach (UserFriendsCallbackDataFriend friend in userFriendsData.friends)
        {
            Debug.Log($"{nameof(friend.uid)}  {friend.uid}!");
            Debug.Log($"{nameof(friend.nick)}  {friend.nick}!");
            Debug.Log($"{nameof(friend.slug)}  {friend.slug}!");
            Debug.Log($"{nameof(friend.avatar)}  {friend.avatar}!");

        }
    }

    private void OnRegisterUserCallback(object sender, UserInfoCallbackData userInfoData)
    {
        // Executed only if loginStatus was 1, you need to reload the iframe
        
        if (userInfoData.status != "ok")
        {
            Debug.Log($"User not registered. Status: {userInfoData.status}. Error: {userInfoData.errmsg}");
            // Allow the user to retry the registration.
            return;
        }

        /*
        https://documentation.vkplay.ru/f2p_vkp/f2pb_js_vkp#registerUser
            To ensure that all parameters after calling the registerUser method are transferred to the iframe with the game, 
            you need to reload the page with the game using the reloadWindow method.
        */
        _vKPlay.ReloadGameWindow();
    }

    private void OnGetLoginStatusCallback(object sender, GetLoginStatusCallbackData loginStatusData)
    {
        _loginStatusData = loginStatusData;
        Debug.Log(loginStatusData);
    }

    private void OnUserSocialFriendsCallback(object sender, UserSocialFriendsCallbackData userSocialFriendsData)
    {
        foreach (UserSocialFriendsCallbackDataFriend friend in userSocialFriendsData.friends)
        {
            Debug.Log($"{nameof(friend.online)}  {friend.online}!");
            Debug.Log($"{nameof(friend.nick)}  {friend.nick}!");
            Debug.Log($"{nameof(friend.slug)}  {friend.slug}!");
            Debug.Log($"{nameof(friend.avatar)}  {friend.avatar}!");
        }
    }

    #endregion
    
    #region Advertisement_Callbacks

    private void OnAdsCallback(object sender, AdsCallbackData adsData)
    {
        if (adsData.type == "adError")
            Debug.Log($"{adsData.type} with code {adsData.code}");
    }

    #endregion
    
    #region Payment_Callbacks

    private void OnPaymentWindowClosedCallback(object sender, PaymentWindowClosedCallbackData e) => 
        Debug.Log($"WindowClosed");
    private void OnPaymentFrameUrlCallback(object sender, PaymentFrameUrlCallbackData paymentFrameUrlData) =>
        Debug.Log(paymentFrameUrlData.url);
    private void OnPaymentReceivedCallback(object sender, PaymentReceivedCallbackData paymentReceivedData) =>
        Debug.Log($"Payment received by {paymentReceivedData.uid}");
    private void OnConfirmWindowClosedCallback(object sender, ConfirmWindowClosedCallbackData confirmWindowClosedData) => 
        Debug.Log($"Window Closed");

    #endregion
    
    #endregion

}