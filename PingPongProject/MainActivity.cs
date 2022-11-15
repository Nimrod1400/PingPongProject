using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using BusinessLogic;

namespace PingPongProject
{
    [Activity(Label = "@string/app_name", 
        Theme = "@style/AppTheme", 
        MainLauncher = true,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        BL logic = new BL();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Window.AddFlags(Android.Views.WindowManagerFlags.KeepScreenOn |
                Android.Views.WindowManagerFlags.Fullscreen);
            Window.ClearFlags(Android.Views.WindowManagerFlags.ForceNotFullscreen);

            logic.OnMatchEnd += () => { };
            var addScoreToFirstPlayer = FindViewById<Button>(Resource.Id.buttonFirstPlayer);

            addScoreToFirstPlayer.Click += delegate
            {
                logic.IncrementFirstSideScore();
                UpdateView();
            };


            var addScoreToSecondPlayer = FindViewById<Button>(Resource.Id.buttonSecondPlayer);

            addScoreToSecondPlayer.Click += delegate
            {
                logic.IncrementSecondSideScore();
                UpdateView();
            };

        }
        private void UpdateView()
        {
            var FirstPlayerSideScore = FindViewById<TextView>(Resource.Id.FirstPlayerSideScoreView);
            FirstPlayerSideScore.Text = logic.GetScore(1).ToString();
            var SecondPlayerSideScore = FindViewById<TextView>(Resource.Id.SecondPlayerSideScoreView);
            SecondPlayerSideScore.Text = logic.GetScore(2).ToString();

            var FirstPlayerMatchesScore = FindViewById<TextView>(Resource.Id.FirstPlayerMatchesScoreView);
            FirstPlayerMatchesScore.Text = logic.GetMatchesScore(1).ToString();
            var SecondPlayerMatchesScore = FindViewById<TextView>(Resource.Id.SecondPlayerMatchesScoreView);
            SecondPlayerMatchesScore.Text = logic.GetMatchesScore(2).ToString();

        }

    }
}