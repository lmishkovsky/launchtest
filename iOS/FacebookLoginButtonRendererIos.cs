﻿using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Facebook.LoginKit;
using Facebook.CoreKit;
using launchtest;
using launchtest.iOS;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRendererIos))]

namespace launchtest.iOS
{
	public class FacebookLoginButtonRendererIos : ButtonRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
                UIButton button = Control;

				button.TouchUpInside += delegate
				{
					HandleFacebookLoginClicked();
				};
			}

			if (AccessToken.CurrentAccessToken != null)
			{
				App.PostSuccessFacebookAction(AccessToken.CurrentAccessToken.ToString());
			}
		}

		void HandleFacebookLoginClicked()
		{
			if (AccessToken.CurrentAccessToken != null)
			{
				App.PostSuccessFacebookAction(AccessToken.CurrentAccessToken.ToString());
			}
			else
			{
				var window = UIApplication.SharedApplication.KeyWindow;
				var vc = window.RootViewController;
				while (vc.PresentedViewController != null)
				{
					vc = vc.PresentedViewController;
				}

				var manager = new LoginManager();
				manager.LogInWithReadPermissions(new string[] { "public_profile" },
												 vc,
												 (result, error) =>
												 {
													 if (error == null && !result.IsCancelled)
													 {
														 App.PostSuccessFacebookAction(result.Token.ToString());
													 }
												 });
			}

		}
	}
}