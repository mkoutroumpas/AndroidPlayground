using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace PlaygroundTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            #region CustomShapeView example
            var csvCustomShapeView = FindViewById<CustomShapeView>(Resource.Id.csvCustomShapeView);
            csvCustomShapeView.SetImageFromResource(Resource.Drawable.home);
            csvCustomShapeView.SetBackgroundColor(Resources.GetColor(Resource.Color.white));
            #endregion
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
	}
}

