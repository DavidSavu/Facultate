using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using SupportToolbar=Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Android.Graphics;

namespace Tinder
{
	//asta e un comentariu1234123123
	//lloll
	[Activity (Label = "Tinder", MainLauncher = true, Icon = "@mipmap/icon", Theme="@style/MyTheme")]
	public class MainActivity : ActionBarActivity, ViewTreeObserver.IOnScrollChangedListener 
	{
		private SupportToolbar mToolbar;
		private DrawerLayout mDrawerLayout;
		private Android.Support.V7.App.ActionBarDrawerToggle mDrawerToggle;

		private ViewPager viewPager;
		private PagerAdapter pagerAdapter;

		private ScrollView mScrollView;
		private int mScreenSize;
		private const int FULLY_INVISIBILE_AT = 2;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);

			mToolbar = FindViewById<SupportToolbar> (Resource.Id.toolbar);
			mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			mScrollView = FindViewById<ScrollView> (Resource.Id.scrollView1);

			SetSupportActionBar (mToolbar);

//			tampenia asta poti sa o stergi de mai jos nu face nimic
			mDrawerToggle = new Android.Support.V7.App.ActionBarDrawerToggle (this, mDrawerLayout, 0, 0);
			mDrawerLayout.SetDrawerListener(mDrawerToggle);
			SupportActionBar.SetHomeButtonEnabled(true);
			SupportActionBar.SetDisplayShowTitleEnabled(false);
			mDrawerToggle.SyncState();

			//aici face tranzitia
			pagerAdapter = new DemoPagerAdapter(SupportFragmentManager);

			viewPager = this.FindViewById<ViewPager>(Resource.Id.pager);
			viewPager.Adapter = pagerAdapter;

			if (viewPager.CurrentItem == 2) {
			}

			//aici facem ca bara sa dispara in momentul cand faci scroll
			//mai intai calculam lungimea ecranului
			Point size= new Point();
			Display display = WindowManager.DefaultDisplay;
			display.GetSize (size);
			mScreenSize = size.Y;

			mScrollView.ViewTreeObserver.AddOnScrollChangedListener (this);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			mDrawerToggle.OnOptionsItemSelected (item);
			return base.OnOptionsItemSelected (item);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.action_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}


		public float GetOpacity()
		{
			float fullInvisibleAtPx = mScreenSize / FULLY_INVISIBILE_AT;

			float alpha = fullInvisibleAtPx / mScrollView.ScrollY;
			if (alpha > 1) {
				return 1;
			} else if (alpha < 0) {
				return 0;
			}
			return alpha;
		}

		public void OnScrollChanged()
		{
			mToolbar.SetBackgroundColor(Color.Argb((int)(GetOpacity()*250),50,153,204));
		}
			
	}
}
