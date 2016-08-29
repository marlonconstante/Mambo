using Akavache;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Mobishop.Infrastructure.Repositories.Commons.Caching;
using Mobishop.Infrastructure.Repositories.FunctionalTests.VTex.Products;

namespace Mobishop.Infrastructure.Repositories.FunctionalTests.Android
{
    [Activity(Label = "NUnit 3.0", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Cache.Initialize("MobiTests");


            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var nunit = new NUnit.Runner.App
            {
                AutoRun = false
            };
            nunit.AddTestAssembly(typeof(VtexProductRepositoryTest).Assembly);

            LoadApplication(nunit);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Cache.Shutdown();
        }
    }
}

