using System;
using AOT;
using System.Runtime.InteropServices;
using UnityEngine;


public class VKPlayWeb : MonoBehaviour
{
    private static GameObject _instance;
    private static VKPlayWeb _componentInstance;
    private static Action s_onInitializeSuccessCallback;
    
    public event EventHandler<AdsCallbackData> AdsCallback;
    public event EventHandler<UserInfoCallbackData> UserInfoCallback;
    public event EventHandler<UserInfoCallbackData> RegisterUserCallback;
    public event EventHandler<UserProfileCallbackData> UserProfileCallback;
    public event EventHandler<UserFriendsCallbackData> UserFriendsCallback;
    public event EventHandler<GetAuthTokenCallbackData> GetAuthTokenCallback;
    public event EventHandler<GetLoginStatusCallbackData> GetLoginStatusCallback;
    public event EventHandler<PaymentReceivedCallbackData> PaymentReceivedCallback;
    public event EventHandler<PaymentFrameUrlCallbackData> PaymentFrameUrlCallback;
    public event EventHandler<UserSocialFriendsCallbackData> UserSocialFriendsCallback;
    public event EventHandler<ConfirmWindowClosedCallbackData> ConfirmWindowClosedCallback;
    public event EventHandler<PaymentWindowClosedCallbackData> PaymentWindowClosedCallback;
    
    public static VKPlayWeb Instance
    {
        get
        {
            if (_instance == null && _componentInstance == null)
            {
                _instance = new GameObject(nameof(VKPlayWeb));
                _componentInstance = _instance.AddComponent<VKPlayWeb>();
            }

            return _componentInstance;
        }
    }

    void Awake()
    {
        VKPlayWeb i = Instance;
        if (i != null && i != this)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
    }

    #region Main
    
    [DllImport("__Internal")]
    private static extern void Initialize(int gmrIdInt, string gameObjectName, Action onSuccessCallback);

    /// <summary>
    /// This method initializes the JS API, called once
    /// <br/>
    /// Calls the callback <see cref="onSuccessCallback"/>
    /// </summary>
    /// <param name="gmrIdInt">Your GMR ID from System Properties</param>
    public void Initialize(int gmrIdInt, Action onSuccessCallback)
    {
        s_onInitializeSuccessCallback = onSuccessCallback;
        Initialize(gmrIdInt, gameObject.name, OnInitializeSuccessCallback);
    }
    
    [DllImport("__Internal")]
    private static extern bool IsInitialized();
    
    /// <summary>
    /// This method returns the initialization state
    /// <br/>
    /// Returns <see cref="true"/>  or <see cref="false"/>
    /// </summary>
    public bool GetIsInitialized() => IsInitialized();
    
    [DllImport("__Internal")]
    private static extern void ReloadWindow();
    
    /// <summary>
    /// This method reloads the game window and updates the iframe parameters
    /// </summary>
    public void ReloadGameWindow() => ReloadWindow();
    
    #endregion

    #region User and Social
    
    [DllImport("__Internal")]
    private static extern void GetLoginStatus();
    
    /// <summary>
    /// This method gets information about the current user status.
    /// <br/>
    /// Calls the callback <see cref="GetLoginStatusCallback"/>
    /// </summary>
    public void GetUserLoginStatus() => GetLoginStatus();

    [DllImport("__Internal")]
    private static extern void RegisterUser();
    
    /// <summary>
    /// This method allows you to call the user registration form
    /// <br/>
    /// Calls the callback <see cref="RegisterUserCallback"/>
    /// </summary>
    public void registerUser() => RegisterUser();

    [DllImport("__Internal")]
    private static extern void GetAuthToken();
    
    /// <summary>
    /// This method allows you to get an authorization token for the current user
    /// <br/>
    /// Calls the callback <see cref="GetAuthTokenCallback"/>
    /// </summary>
    public void GetAuthorizationToken() => GetAuthToken();

    [DllImport("__Internal")]
    private static extern void AuthUser();
    
    /// <summary>
    /// This method calls the user authorization form and reloads the page
    /// </summary>
    public void AuthorizeUser() => AuthUser();

    [DllImport("__Internal")]
    private static extern void UserProfile();
    
    /// <summary>
    /// This method allows you to get more detailed information about the user
    /// <br/>
    /// Calls the callback <see cref="UserProfileCallback"/>
    /// </summary>
    public void GetUserProfile() => UserProfile();

    [DllImport("__Internal")]
    private static extern void UserInfo();
    
    /// <summary>
    /// This method allows you to get information about the user (for example, to calculate the signature)
    /// <br/>
    /// Calls the callback <see cref="UserInfoCallback"/>
    /// </summary>
    public void GetUserInfo() => UserInfo();
    
    [DllImport("__Internal")]
    private static extern void UserFriends();
    
    /// <summary>
    /// This method allows you to get a list of friends of a user in the project
    /// <br/>
    /// Calls the callback <see cref="UserFriendsCallback"/>
    /// </summary>
    public void GetUserFriends() => UserFriends();

    [DllImport("__Internal")]
    private static extern void UserSocialFriends();
    
    /// <summary>
    /// This method allows you to get a list of user's friends (not tied to the project)
    /// <br/>
    /// Calls the callback <see cref="UserSocialFriendsCallback"/>
    /// </summary>
    public void GetUserSocialFriends() => UserSocialFriends();
    
    #endregion

    #region Advertisement

    [DllImport("__Internal")]
    private static extern void ShowAds(string adsConfigJsonString);
    
    /// <summary>
    /// This method allows you to show the player an ad
    /// <br/>
    /// See <see cref="VKPlayWebAdsConfig"/>
    /// </summary>
    /// <param name="adsConfig">Ad display settings</param>
    public void ShowAd(VKPlayWebAdsConfig adsConfig) => ShowAds(JsonUtility.ToJson(adsConfig));

    #endregion

    #region Items and Payment

    [DllImport("__Internal")]
    private static extern void PaymentFrame(string argsJsonString);
    
    /// <summary>
    /// Shows the payment form
    /// <br/>
    /// Calls the callbacks <see cref="PaymentReceivedCallback"/> and <see cref="PaymentWindowClosedCallback"/>
    /// </summary>
    /// <param name="args">Payment form display parameters</param>
    public void ShowPaymentForm(VKPlayPaymentFrameArgs args) => PaymentFrame(JsonUtility.ToJson(args));

    [DllImport("__Internal")]
    private static extern void PaymentFrameItem(string argsJsonString);
    
    public void GetPaymentFrameItem(VKPlayPaymentFrameItemArgs args) => PaymentFrameItem(JsonUtility.ToJson(args));

    [DllImport("__Internal")]
    private static extern void PaymentFrameUrl(string argsJsonString);
    
    /// <summary>
    /// Generates a link to the payment form
    /// <br/>
    /// Calls the callback <see cref="PaymentFrameUrlCallback"/>
    /// </summary>
    /// <param name="args">Payment form parameters</param>
    public void GeneratePaymentFrameUrl(VKPlayPaymentFrameArgs args) => PaymentFrameUrl(JsonUtility.ToJson(args));
    
    [DllImport("__Internal")]
    private static extern void GetGameInventoryItems();
    
    /// <summary>
    /// This method allows you to get information about in-game items
    /// <br/>
    /// TODO: implement callback
    /// </summary>
    public void GetInGameInventoryItems() => GetGameInventoryItems();

    #endregion

    [MonoPInvokeCallback(typeof(Action))]
    private static void OnInitializeSuccessCallback() => s_onInitializeSuccessCallback?.Invoke();

    #region Methods called by Api

    public void ThrowGetLoginStatus(string a) =>
        GetLoginStatusCallback?.Invoke(this, JsonUtility.FromJson<GetLoginStatusCallbackData>(a));

    public void ThrowUserInfo(string a) =>
        UserInfoCallback?.Invoke(this, JsonUtility.FromJson<UserInfoCallbackData>(a));

    public void ThrowUserProfile(string a) =>
        UserProfileCallback?.Invoke(this, JsonUtility.FromJson<UserProfileCallbackData>(a));

    public void ThrowRegisterUser(string a) =>
        RegisterUserCallback?.Invoke(this, JsonUtility.FromJson<UserInfoCallbackData>(a));

    public void ThrowPaymentFrameUrl(string a) =>
        PaymentFrameUrlCallback?.Invoke(this, new PaymentFrameUrlCallbackData() { status = "ok", url = a });

    public void ThrowGetAuthToken(string a) =>
        GetAuthTokenCallback?.Invoke(this, JsonUtility.FromJson<GetAuthTokenCallbackData>(a));

    public void ThrowPaymentReceived(string a) =>
        PaymentReceivedCallback?.Invoke(this, JsonUtility.FromJson<PaymentReceivedCallbackData>(a));

    public void ThrowPaymentWindowClosed() =>
        PaymentWindowClosedCallback?.Invoke(this, new PaymentWindowClosedCallbackData { status = "ok" });

    public void ThrowConfirmWindowClosed() =>
        ConfirmWindowClosedCallback?.Invoke(this, new ConfirmWindowClosedCallbackData { status = "ok" });

    public void ThrowAds(string a) =>
        AdsCallback?.Invoke(this, JsonUtility.FromJson<AdsCallbackData>(a));

    public void ThrowUserFriends(string a) =>
        UserFriendsCallback?.Invoke(this, JsonUtility.FromJson<UserFriendsCallbackData>(a));

    public void ThrowUserSocialFriends(string a) =>
        UserSocialFriendsCallback?.Invoke(this, JsonUtility.FromJson<UserSocialFriendsCallbackData>(a));
    
    #endregion
}
