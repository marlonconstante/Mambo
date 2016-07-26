using Mambo.Services;
using Xamarin.Forms;

namespace Mambo
{
	/// <summary>
	/// App.
	/// </summary>
	public class App : Application
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.App"/> class.
		/// </summary>
		public App()
		{
			// The root page of your application
			var content = new ContentPage {
				Title = "Mambo",
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};

			MainPage = new NavigationPage(content);
		}

		/// <summary>
		/// Ons the start.
		/// </summary>
		/// <returns>The start.</returns>
		protected override void OnStart()
		{
			ServiceLocator.Register();
		}

		/// <summary>
		/// Ons the sleep.
		/// </summary>
		/// <returns>The sleep.</returns>
		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		/// <summary>
		/// Ons the resume.
		/// </summary>
		/// <returns>The resume.</returns>
		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}