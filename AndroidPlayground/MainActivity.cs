using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;

namespace PlaygroundTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _btnTest;

        /// <summary>
        /// OnCreate lifecycle method.
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            #region CustomShapeView example
            var csvCustomShapeView = FindViewById<CustomShapeView>(Resource.Id.csvCustomShapeView);
            csvCustomShapeView.SetImageFromResource(Resource.Drawable.home);
            csvCustomShapeView.SetBackgroundColor(new Color(ContextCompat.GetColor(this, Resource.Color.white)));
            #endregion

            #region TestButton
            _btnTest = FindViewById<Button>(Resource.Id.btnTest);
            _btnTest.Click += BtnTest_Click;
            #endregion
        }

        /// <summary>
        /// Event handler method, used for UI-triggered tests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTest_Click(object sender, System.EventArgs e)
        {
            
        }

        /// <summary>
        /// Detach all UI event handlers here.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (_btnTest != null)
            {
                _btnTest.Click -= BtnTest_Click;
            }
        }
    }
}

