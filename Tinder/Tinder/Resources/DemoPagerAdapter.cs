using System;
using Android.Support.V4.App;

namespace Tinder
{
	internal class DemoPagerAdapter : FragmentPagerAdapter
	{
		Fragment[] _fragment;

		public DemoPagerAdapter(FragmentManager fm) : base(fm){}

		private void Init ()
		{
			if (_fragment == null) {
				_fragment = new Fragment[] { 
					new PagerFragment1 (),
					new PagerFragment2 ()
				};
			}
		}
		public override Fragment GetItem(int position)
		{
			return _fragment [position];
		}

		public override int Count
		{
			get {
				Init ();
				return _fragment.Length;}
		}
	}
}

