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
	public class PagerFragment2 : Fragment
//	, ViewTreeObserver.IOnScrollChangedListener 
	{

//		private ScrollView mScrollView;
//		private int mScreenSize;
//		private const int FULLY_INVISIBILE_AT = 2;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.Test, container, false);
//			mScrollView = view.FindViewById<ScrollView> (Resource.Id.scrollView1);
//
//			var metrics = Resources.DisplayMetrics;
//			var display = ConvertPixelsToDp(metrics.HeightPixels);
//			mScreenSize = display;

			return view;
		}

//		private int ConvertPixelsToDp(float pixelValue)
//		{
//			var dp = (int) ((pixelValue)/Resources.DisplayMetrics.Density);
//			return dp;
//		}
//
//		public float GetOpacity()
//		{
//			float fullInvisibleAtPx = mScreenSize / FULLY_INVISIBILE_AT;
//
//			float alpha = mScrollView.ScrollY / fullInvisibleAtPx;
//			if (alpha > 1) {
//				return 1;
//			} else if (alpha < 0) {
//				return 0;
//			}
//			return alpha;
//		}
//
//		public void OnScrollChanged()
//		{
//			
//		}
	}
}

