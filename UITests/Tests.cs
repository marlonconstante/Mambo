using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Mambo.UITests
{
	/// <summary>
	/// Tests.
	/// </summary>
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		/// <summary>
		/// The app.
		/// </summary>
		IApp app;

		/// <summary>
		/// The platform.
		/// </summary>
		Platform platform;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Mambo.UITests.Tests"/> class.
		/// </summary>
		/// <param name="platform">Platform.</param>
		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		/// <summary>
		/// Befores the each test.
		/// </summary>
		/// <returns>The each test.</returns>
		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		/// <summary>
		/// Welcomes the text is displayed.
		/// </summary>
		/// <returns>The text is displayed.</returns>
		[Test]
		public void WelcomeTextIsDisplayed()
		{
			AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin Forms!"));
			app.Screenshot("Welcome screen.");

			Assert.IsTrue(results.Any());
		}
	}
}