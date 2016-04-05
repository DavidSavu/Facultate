
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json.Linq;

namespace IncercareAndroidApp
{
	[Activity (Label = "ActivityResults")]			
	public class ActivityResults : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.ResultsLayout);

			TextView txt1 = FindViewById<TextView> (Resource.Id.txt1);

			string A = "";
			string F = "";
			A = Intent.GetStringExtra ("RAdevarat");
			F = Intent.GetStringExtra ("RFals");
			string raspuns1 = "";
			string raspunsF = "";


			if (A.Length < 4) {
				raspuns1 = "Nu ai raspuns cu A la nici o intrebare";
			} else {
				var JAA = JArray.Parse (A);
				foreach(var JA in JAA)
				raspuns1 += "Raspunsul tau la intrebarea numarul :" + JA ["Id"].ToString () + JA ["Quest"].ToString () + "a fost :" + JA ["Answere"].ToString ();
			}


			if (F.Length < 4) {
				raspunsF = "Nu ai raspuns cu F la nici o intrebare";
			} else {
				var JFA = JArray.Parse (F);
				foreach(var JF in JFA)
				raspunsF += "Raspunsul tau la intrebarea numarul :" + JF ["Id"].ToString ()+". " + JF ["Quest"].ToString () + "a fost :" + JF ["Answere"].ToString ();
			}

			txt1.Text = raspuns1 + " iar raspunsurile cu F au fost " + raspunsF;
		}
	}
}

