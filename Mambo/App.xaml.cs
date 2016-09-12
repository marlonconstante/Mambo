using FreshMvvm;
using Mambo.Navigations;
using Mambo.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Mambo
{
	/// <summary>
	/// App.
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.App"/> class.
		/// </summary>
		public App()
		{
			InitializeComponent();
			AppBootstrapper.Initialize();

			var homePage = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
			MainPage = new BasketNavigationPage(homePage);
		}

		/// <summary>
		/// Ons the start.
		/// </summary>
		/// <returns>The start.</returns>
		protected override void OnStart()
		{
		}

		/// <summary>
		/// Ons the sleep.
		/// </summary>
		/// <returns>The sleep.</returns>
		protected override void OnSleep()
		{
		}

		/// <summary>
		/// Ons the resume.
		/// </summary>
		/// <returns>The resume.</returns>
		protected override void OnResume()
		{
		}
	}
}