using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace PingPongProject
{
    [Activity(Label = "@string/app_name", 
        Theme = "@style/AppTheme", 
        MainLauncher = true,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Window.AddFlags(Android.Views.WindowManagerFlags.KeepScreenOn |
                Android.Views.WindowManagerFlags.Fullscreen);
            Window.ClearFlags(Android.Views.WindowManagerFlags.ForceNotFullscreen);
            
        }
    }
}