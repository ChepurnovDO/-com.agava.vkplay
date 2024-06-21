using UnityEngine;
using UnityEngine.UI;

public class ButtonsPressHandler : MonoBehaviour
{
    [SerializeField] private Button _authButton;
    [SerializeField] private Button _registerUserButton;
    [SerializeField] private Button _userProfileButton;
    [SerializeField] private Button _userInfoButton;
    [SerializeField] private Button _friendsButton;
    [SerializeField] private Button _socialFriendsButton;
    [SerializeField] private Button _getAuthTokenButton;
    [SerializeField] private Button _rewardAdButton;
    [SerializeField] private Button _interstitialAdButton;
    [SerializeField] private Button _getInitStatusButton;
    [SerializeField] private Button _getLoginStatusButton;

    [SerializeField] private ApiExample _apiExample;

    private void OnEnable()
    {
        _authButton.onClick.AddListener(OnAuthButtonClick);
        _friendsButton.onClick.AddListener(OnFriendsButtonClick);
        _userInfoButton.onClick.AddListener(OnUserInfoButtonClick);
        _rewardAdButton.onClick.AddListener(OnRewardAdButtonClick);
        _userProfileButton.onClick.AddListener(OnUserProfileButtonClick);
        _getAuthTokenButton.onClick.AddListener(OnGetAuthTokenButtonClick);
        _registerUserButton.onClick.AddListener(OnRegisterUserButtonClick);
        _getInitStatusButton.onClick.AddListener(OnGetInitStatusButtonClick);
        _socialFriendsButton.onClick.AddListener(OnSocialFriendsButtonClick);
        _interstitialAdButton.onClick.AddListener(OnInterstitialAdButtonClick);
        _getLoginStatusButton.onClick.AddListener(OnGetLoginStatusButtonClick);
    }


    private void OnDisable()
    {
        _authButton.onClick.RemoveListener(OnAuthButtonClick);
        _friendsButton.onClick.RemoveListener(OnFriendsButtonClick);
        _rewardAdButton.onClick.RemoveListener(OnRewardAdButtonClick);
        _userInfoButton.onClick.RemoveListener(OnUserInfoButtonClick);
        _userProfileButton.onClick.RemoveListener(OnUserProfileButtonClick);
        _getAuthTokenButton.onClick.RemoveListener(OnGetAuthTokenButtonClick);
        _registerUserButton.onClick.RemoveListener(OnRegisterUserButtonClick);
        _getLoginStatusButton.onClick.AddListener(OnGetLoginStatusButtonClick);
        _socialFriendsButton.onClick.RemoveListener(OnSocialFriendsButtonClick);
        _getInitStatusButton.onClick.RemoveListener(OnGetInitStatusButtonClick);
        _interstitialAdButton.onClick.RemoveListener(OnInterstitialAdButtonClick);
    }

    private void OnAuthButtonClick() => _apiExample.AuthUser();
    private void OnRewardAdButtonClick() => _apiExample.ShowRewardAd();
    private void OnUserInfoButtonClick() => _apiExample.RequestUserInfo();
    private void OnGetAuthTokenButtonClick() => _apiExample.GetAuthToken();
    private void OnRegisterUserButtonClick() => _apiExample.RegisterUser();
    private void OnFriendsButtonClick() => _apiExample.RequestUserFriends();
    private void OnGetInitStatusButtonClick() => _apiExample.GetInitStatus();
    private void OnUserProfileButtonClick() => _apiExample.RequestUserProfile();
    private void OnInterstitialAdButtonClick() => _apiExample.ShowInterstitialAd();
    private void OnGetLoginStatusButtonClick() => _apiExample.GetUserLoginStatus();
    private void OnSocialFriendsButtonClick() => _apiExample.RequestUserSocialFriends();

}
