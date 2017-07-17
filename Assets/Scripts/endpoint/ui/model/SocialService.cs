using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

namespace endpoint.ui
{
    public class SocialService : ISocialService
    {
		[Inject]
        public UpdateLoginStatusSignal updateLoginStatusSignal { get; set; }

        public void Init()
        {
            if (!FB.IsInitialized)
            {
                FB.Init(InitCallback, OnHideUnity);
            } else
            {
                FB.ActivateApp();
            }
        }

		#region FB Init
		private void InitCallback()
		{
			Debug.Log("InitCallback");

			// App Launch events should be logged on app launch & app resume
			// See more: https://developers.facebook.com/docs/app-events/unity#quickstart
			FBAppEvents.LaunchEvent();

			if (FB.IsLoggedIn)
			{
				Debug.Log("Already logged in");
				OnLoginComplete();
			}
		}

		private void OnHideUnity(bool isGameShown)
		{
			if (!isGameShown)
			{
				// Pause the game - we will need to hide
				Time.timeScale = 0;
			}
			else
			{
				// Resume the game - we're getting focus again
				Time.timeScale = 1;
			}
		}
		#endregion

		#region Login
		public void OnFacebookLoginClick()
		{
			Debug.Log("OnLoginClick");

			// Call Facebook Login for Read permissions of 'public_profile', 'user_friends', and 'email'
			FBLogin.PromptForLogin(OnLoginComplete);
		}

		private void OnLoginComplete()
		{
			Debug.Log("OnLoginComplete");
            updateLoginStatusSignal.Dispatch();
			if (!FB.IsLoggedIn)
			{
				return;
			}
		}
		#endregion

        public bool isLoggedIn()
        {
            return FB.IsLoggedIn;
        }
	}
}