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

namespace WhiskyNotes.Activities
{
	[Activity(Label = "Notes", Theme = "@style/AppTheme.NoActionBar")]
	public class Notes : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.notes);

			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.SetTitleTextColor(Android.Graphics.Color.White);

			SetActionBar(toolbar);
		}
	}
}