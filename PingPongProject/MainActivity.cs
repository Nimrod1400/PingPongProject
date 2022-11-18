using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Model;

namespace PingPongProject
{
    [Activity(Label = "@string/app_name",
        Theme = "@style/AppTheme",
        MainLauncher = true,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private Logic logic = new Logic();

        private Button addScoreToFirstPlayerButton;
        private Button addScoreToSecondPlayerButton;

        private TextView FirstPlayerSideScoreView;
        private TextView SecondPlayerSideScoreView;

        private TextView FirstPlayerMatchesScoreView;
        private TextView SecondPlayerMatchesScoreView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            Window.AddFlags(Android.Views.WindowManagerFlags.KeepScreenOn |
                Android.Views.WindowManagerFlags.Fullscreen);
            Window.ClearFlags(Android.Views.WindowManagerFlags.ForceNotFullscreen);

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            InitializeInterfaceElements();
            logic.OnMatchEnd += () => { }; // TODO: activity which called when match ends

            
            addScoreToFirstPlayerButton.Click += delegate
            {
                logic.IncrementScore(side: 1);
                UpdateView();
            };

            addScoreToSecondPlayerButton.Click += delegate
            {
                logic.IncrementScore(side: 2);
                UpdateView();
            };
        }

        private void InitializeInterfaceElements()
        {
            addScoreToFirstPlayerButton = FindViewById<Button>(Resource.Id.buttonFirstPlayer);
            addScoreToSecondPlayerButton = FindViewById<Button>(Resource.Id.buttonSecondPlayer);

            FirstPlayerSideScoreView = FindViewById<TextView>(Resource.Id.FirstPlayerSideScoreView);
            SecondPlayerSideScoreView = FindViewById<TextView>(Resource.Id.SecondPlayerSideScoreView);

            FirstPlayerMatchesScoreView = FindViewById<TextView>(Resource.Id.FirstPlayerMatchesScoreView);
            SecondPlayerMatchesScoreView = FindViewById<TextView>(Resource.Id.SecondPlayerMatchesScoreView);

        }

        private void UpdateView()
        {
            FirstPlayerSideScoreView.Text = logic.GetScore(side: 1).ToString();
            SecondPlayerSideScoreView.Text = logic.GetScore(side: 2).ToString();

            FirstPlayerMatchesScoreView.Text = logic.GetMatchesScore(side: 1).ToString();
            SecondPlayerMatchesScoreView.Text = logic.GetMatchesScore(side: 2).ToString();

            //if (logic.GetServingSide() == 1)
            //    addScoreToFirstPlayerButton.SetBackgroundColor(new Android.Graphics.Color() { R = 0, G = 0, B = 255 });
        }
    }
}