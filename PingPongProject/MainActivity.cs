using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using AndroidX.AppCompat.App;
using Model;
using System.Threading;

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

            Window.AddFlags(WindowManagerFlags.KeepScreenOn);

            InitializeInterfaceElements();

            Main();            
        }

        private void Main()
        {
            logic.OnMatchEnd += () => { }; // TODO: activity which called when match ends

            UpdateServingSideIndicator();

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

            UpdateServingSideIndicator();
        }

        private void SetButtonColor(Button button, Color color)
        {
            button.SetBackgroundColor(color);
        }

        private void UpdateServingSideIndicator()
        {
            if (logic.WhoIsServing == 1)
            {
                SetButtonColor(addScoreToFirstPlayerButton, Color.White);
                SetButtonColor(addScoreToSecondPlayerButton, new Color(Resource.Color.colorWhoIsServing));
            }
            else if (logic.WhoIsServing == 2)
            {
                SetButtonColor(addScoreToSecondPlayerButton, Color.White);
                SetButtonColor(addScoreToFirstPlayerButton, new Color(Resource.Color.colorWhoIsServing));
            }
        }
    }
}