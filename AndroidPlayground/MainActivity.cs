using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Threading;

namespace PlaygroundTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _btnTestBlocking;

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
            _btnTestBlocking = FindViewById<Button>(Resource.Id.btnTestBlocking);
            _btnTestBlocking.Click += BtnTestBlocking_Click;
            #endregion
        }

        /// <summary>
        /// Use this method to demonstrate the blocking main thread scenario. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTestBlocking_Click(object sender, EventArgs e)
        {
            Helpers.Heavy_Task();
        }

        /// <summary>
        /// Detach all UI event handlers here.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (_btnTestBlocking != null)
            {
                _btnTestBlocking.Click -= BtnTestBlocking_Click;
            }
        }
    }
}

