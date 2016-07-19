using Xamarin.UITest;

namespace Mambo.UITests
{
	/// <summary>
	/// App initializer.
	/// </summary>
	public class AppInitializer
	{
		/// <summary>
		/// Starts the app.
		/// </summary>
		/// <returns>The app.</returns>
		/// <param name="platform">Platform.</param>
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
				return ConfigureApp.Android.StartApp();
			}

			return ConfigureApp.iOS.StartApp();
		}
	}
}