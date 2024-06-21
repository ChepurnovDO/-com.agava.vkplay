mergeInto(LibraryManager.library, {

	isInitialized: false,

	Initialize: function(gmrIdInt, gameObjectNameStringPtr, successCallbackPtr) {
		if (typeof window.__VkExternalApi !== 'undefined') {
			console.log('vkplay api is already initialized');
			return;
		}
		
		let sf = (typeof UTF8ToString === 'undefined') ? Pointer_stringify : UTF8ToString;
		var unityGameObjectName = sf(gameObjectNameStringPtr);
		window.__VkExternalApi = null;
		
		let scriptTag = document.createElement('script');
		scriptTag.type = 'text/javascript';
		scriptTag.src = '//vkplay.ru/app/' + gmrIdInt.toString() + '/static/mailru.core.js';
		scriptTag.onload = function(ev) {
			console.log('vkplay api load:');
			console.log(ev);

			let callbacks = {
				appid: gmrIdInt,
				getLoginStatusCallback: function(status) {
					console.log('getLoginStatusCallback'); console.log(status);
					Module.SendMessage(unityGameObjectName, 'ThrowGetLoginStatus', JSON.stringify(status));
				},
				userInfoCallback: function(info) {
					console.log('userInfoCallback'); console.log(info);
					Module.SendMessage(unityGameObjectName, 'ThrowUserInfo', JSON.stringify(info));
				},
				userProfileCallback: function(profile) {
					console.log('userProfileCallback'); console.log(profile);
					Module.SendMessage(unityGameObjectName, 'ThrowUserProfile', JSON.stringify(profile));
				},
				registerUserCallback: function(info) {
					console.log('registerUserCallback'); console.log(info);
					Module.SendMessage(unityGameObjectName, 'ThrowRegisterUser', JSON.stringify(info));
				},
				paymentFrameUrlCallback: function(url) {
					console.log('paymentFrameUrlCallback'); console.log(url);
					Module.SendMessage(unityGameObjectName, 'ThrowPaymentFrameUrl', url);
				},
				getAuthTokenCallback: function(token) {
					console.log('getAuthTokenCallback'); console.log(token);
					Module.SendMessage(unityGameObjectName, 'ThrowGetAuthToken', JSON.stringify(token));
				},
				paymentReceivedCallback: function(data) {
					console.log('paymentReceivedCallback'); console.log(data);
					Module.SendMessage(unityGameObjectName, 'ThrowPaymentReceived', JSON.stringify(data));
				},
				paymentWindowClosedCallback: function() {
					console.log('paymentWindowClosedCallback');
					Module.SendMessage(unityGameObjectName, 'ThrowPaymentWindowClosed');
				},
				confirmWindowClosedCallback: function() {
					console.log('confirmWindowClosedCallback');
					Module.SendMessage(unityGameObjectName, 'ThrowConfirmWindowClosed');
				},
				adsCallback: function(context) {
					console.log('adsCallback'); console.log(context);
					Module.SendMessage(unityGameObjectName, 'ThrowAds', JSON.stringify(context));
				},
				userFriendsCallback: function(data) {
					console.log('userFriendsCallback'); console.log(data);
					Module.SendMessage(unityGameObjectName, 'ThrowUserFriends', JSON.stringify(data));
				},
				userSocialFriendsCallback: function(data) {
					console.log('userSocialFriendsCallback'); console.log(data);
					Module.SendMessage(unityGameObjectName, 'ThrowUserSocialFriends', JSON.stringify(data));
				},
				getGameInventoryItemsCallback: function(data) {
					console.log('getGameInventoryItemsCallback'); console.log(data);
					Module.SendMessage(unityGameObjectName, 'ThrowGetGameInventoryItems', JSON.stringify(data));
				}
			};
			
			let ifapi = window.iframeApi;
			console.log('iframe api:');
			console.log(ifapi);
			
			if ((typeof ifapi) === 'undefined') {
			    console.log('iframeapi error');
			} else {
				ifapi(callbacks).then(
					function(eapi) {
						console.log('vkplay api full load:'); console.log(eapi);
						window.__VkExternalApi = eapi;
						isInitialized = true;
						dynCall('v', successCallbackPtr);
					},
					function(apierr) {
						console.log('vkplay api load error:'); console.log(apierr);
					}
				);
				console.log('vkplay called promise for gameobj ' + unityGameObjectName);
			}
		};
		scriptTag.onerror = function(ev) {
			console.log('vk api script error:'); console.log(ev);
		};
		console.log('vk api appending element:');
		document.head.appendChild(scriptTag);
		console.log('vk api appended, returning...');
	},

	IsInitialized: function () {
        return isInitialized;
    },

	GetLoginStatus: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.getLoginStatus();
		}
	},
	
	RegisterUser: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.registerUser();
		}
	},
	
	GetAuthToken: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.getAuthToken();
		}
	},
	
	AuthUser: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.authUser();
		}
	},
	
	UserProfile: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.userProfile();
		}
	},
	
	UserInfo: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.userInfo();
		}
	},
	
	ReloadWindow: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.reloadWindow();
		}
	},
	
	ShowAds: function(adsConfigJsonString) {
		if (typeof window.__VkExternalApi !== 'undefined') {
			let sf = (typeof UTF8ToString === 'undefined') ? Pointer_stringify : UTF8ToString;
			window.__VkExternalApi.showAds(JSON.parse(sf(adsConfigJsonString)));
		}
	},
	
	PaymentFrame: function(argsJsonString) {
		if (typeof window.__VkExternalApi !== 'undefined') {
			let sf = (typeof UTF8ToString === 'undefined') ? Pointer_stringify : UTF8ToString;
			window.__VkExternalApi.paymentFrame(JSON.parse(sf(argsJsonString)));
		}
	},
	
	PaymentFrameItem: function(argsJsonString) {
		if (typeof window.__VkExternalApi !== 'undefined') {
			let sf = (typeof UTF8ToString === 'undefined') ? Pointer_stringify : UTF8ToString;
			window.__VkExternalApi.paymentFrameItem(JSON.parse(sf(argsJsonString)));
		}
	},
	
	PaymentFrameUrl: function(argsJsonString) {
		if (typeof window.__VkExternalApi !== 'undefined') {
			let sf = (typeof UTF8ToString === 'undefined') ? Pointer_stringify : UTF8ToString;
			window.__VkExternalApi.paymentFrameUrl(JSON.parse(sf(argsJsonString)));
		}
	},
	
	UserFriends: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.userFriends();
		}
	},
	
	UserSocialFriends: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.userSocialFriends();
		}
	},
	
	GetGameInventoryItems: function() {
		if (typeof window.__VkExternalApi !== 'undefined') {
			window.__VkExternalApi.getGameInventoryItems();
		}
	}

});

