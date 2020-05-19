using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace PlaygroundTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _btnTest;

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

            _btnTest = FindViewById<Button>(Resource.Id.btnTest);
            _btnTest.Click += BtnTest_Click;
        }

        private void BtnTest_Click(object sender, System.EventArgs e)
        {
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

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

