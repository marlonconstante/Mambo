using System;
using Android.App;
using Android.Runtime;

namespace Mambo.Android
{
	/// <summary>
	/// Main application.
	/// </summary>
	[Application(Name = "Mambo.MainApplication")]
	public class MainApplication : Application
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.Android.MainApplication"/> class.
		/// </summary>
		/// <param name="handle">Handle.</param>
		/// <param name="ownership">Ownership.</param>
		public MainApplication(IntPtr handle, JniHandleOwnership ownership) : base(handle, ownership)
		{
		}

		/// <summary>
		/// Ons the create.
		/// </summary>
		public override void OnCreate()
		{
			base.OnCreate();

			Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());
		}
	}
}