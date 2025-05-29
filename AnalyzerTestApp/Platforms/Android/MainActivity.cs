using Android.App;
using Android.Content.PM;
using Android.Views;

namespace AnalyzerTestApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
                  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                  ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize,
                  LaunchMode = LaunchMode.SingleTop)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            // Prevent screen from turning off
            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
        }

        protected override void OnPause()
        {
            base.OnPause();

            // Optional: Allow screen to turn off when app is paused
            Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
        }
    }
}
