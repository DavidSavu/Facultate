using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace IncercareAndroidApp
{
	[Activity (Label = "IncercareAndroidApp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
	//	int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			List<string> Ques = new List<string> ();
			Ques.Add ("Ana are 0?");
			Ques.Add ("Ana are 1?");
			Ques.Add ("Ana are 2?");
			int i = 0;

			// Get our button from the layout resource,
			// and attach an event to it
			Button btnA = FindViewById<Button> (Resource.Id.btnA);
			Button btnF = FindViewById<Button> (Resource.Id.btnF);
			Button btnBack = FindViewById<Button> (Resource.Id.btnBack);
			Button btnNext = FindViewById<Button> (Resource.Id.btnNext);
			TextView txtQues = FindViewById<TextView> (Resource.Id.txtQues);

			txtQues.Text = Ques [i].ToString ();
			btnNext.Click += (object sender, System.EventArgs e) => {	
				i++;	
				if(i>=Ques.Count){
					i=0;
				}
				txtQues.Text=Ques[i].ToString();
			};
			btnBack.Click += (object sender, System.EventArgs e) => {	
				i--;	
				if(i<0){
					i=Ques.Count-1;
				}
				txtQues.Text=Ques[i].ToString();
			};


		}
	}
}


