using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Threading.Tasks;

namespace PlaygroundTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _btnTestBlocking;
        private Button _btnTestAddToThreadPool;
        private Button _btnTestAsync;

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

            #region Test Blocking
            _btnTestBlocking = FindViewById<Button>(Resource.Id.btnTestBlocking);
            _btnTestBlocking.Click += BtnTestBlocking_Click;
            #endregion

            #region Test add to thread pool
            _btnTestAddToThreadPool = FindViewById<Button>(Resource.Id.btnTestAddToThreadPool);
            _btnTestAddToThreadPool.Click += BtnTestBlocking_Click;
            #endregion

            #region Test async
            _btnTestAsync = FindViewById<Button>(Resource.Id.btnTestAsync);
            _btnTestAsync.Click += BtnTestAsync_Click;
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
        /// Use this method to demonstrate the add to threadpool scenario. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTestAddToThreadPool_Click(object sender, EventArgs e)
        {
            Task.Run(() => Helpers.Heavy_Task());
        }

        /// <summary>
        /// Use this method to demonstrate the async scenario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnTestAsync_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() => Helpers.Heavy_Task());

            (sender as Button).Text = "Button clicked ...";

            await task;
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

