﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using NControl.Controls.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Mambo.Android
{
	/// <summary>
	/// Main activity.
	/// </summary>
	[Activity(Label = "Mambo", Icon = "@drawable/icon", Theme = "@style/CustomTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		/// <summary>
		/// Ons the create.
		/// </summary>
		/// <returns>The create.</returns>
		/// <param name="bundle">Bundle.</param>
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			NControls.Init();

			Cache.Initialize("Mambo");

			LoadApplication(new App());
		}

		/// <summary>
		/// Ons the destroy.
		/// </summary>
		protected override void OnDestroy()
		{
			base.OnDestroy();

			Cache.Shutdown();
		}
	}
}