using Foundation;
using Mobishop.Infrastructure.Repositories.FunctionalTests.VTex.Products;
using UIKit;

namespace Mobishop.Infrastructure.Repositories.FunctionalTests.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {


        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();

            var nunit = new NUnit.Runner.App
            {
                AutoRun = true
            };
            nunit.AddTestAssembly(typeof(VtexProductRepositoryTest).Assembly);
            LoadApplication(nunit);

            return base.FinishedLaunching(application, launchOptions);
        }
    }
}

