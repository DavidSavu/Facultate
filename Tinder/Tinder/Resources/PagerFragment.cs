using System;
using Android.Support.V4.App;
using Android.Views;
using Android.OS;
using Android.Widget;
using SupportToolbar=Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Graphics;

namespace Tinder
{
	public class PagerFragment1 : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.Mesaje, container, false);
			TextView x = view.FindViewById<TextView> (Resource.Id.textView1);
			x.Text="Page 1";
			return view;
		}
	}
	public class PagerFragment2 : Fragment, ViewTreeObserver.IOnScrollChangedListener 
	{
		View _view;
		private SupportToolbar mToolbar;
		private ScrollView mScrollView;
		private int mScreenSize;
		private const int FULLY_INVISIBILE_AT = 2;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.Test, container, false);
			_view = view;
			mToolbar = view.FindViewById<SupportToolbar> (Resource.Id.toolbar);
			mScrollView=view.FindViewById<ScrollView> (Resource.Id.scrollView1);
			//TODO--> 
			mScreenSize = 800;

			GetOpacity ();
			mScrollView.ViewTreeObserver.AddOnScrollChangedListener (this);

			return view;
		}

		public float GetOpacity()
		{
			float fullInvisibleAtPx = mScreenSize / FULLY_INVISIBILE_AT;

			float alpha = mScrollView.ScrollY / fullInvisibleAtPx;
			if (alpha > 1) {
				return 1;
			} else if (alpha < 0) {
				return 0;
			}
			return alpha;
		}
			
		public void OnScrollChanged ()
		{
			try{
			mToolbar.SetBackgroundColor(Color.Argb((int)(GetOpacity()*250),50,100,204));
			}catch (Exception ex) {
			}
		}
	}
}

