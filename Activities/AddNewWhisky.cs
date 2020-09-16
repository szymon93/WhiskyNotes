using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using WhiskyNotes.Classes;
using WhiskyNotes.Classes.AddWhisky;

namespace WhiskyNotes.Activities
{
	[Activity(Label = "AddNewWhisky",  Theme = "@style/AppTheme.NoActionBar")]
	public class AddNewWhisky : Activity
	{
		private const string WhiskyListFileName = "whisky_list.txt";

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.new_whisky);
			
			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			toolbar.SetTitleTextColor(Android.Graphics.Color.White);

			SetActionBar(toolbar);
			CreateRatingBarsListeners();

			HandleAddWhiskyEvent();

			TextInputEditText whiskyNameTextInput = FindViewById<TextInputEditText>(Resource.Id.whisky_name_text_input);
			ViewCompat.SetBackgroundTintList(whiskyNameTextInput, ColorStateList.ValueOf(Android.Graphics.Color.Gold));
		}

		private void HandleAddWhiskyEvent()
		{
			Button AddWhiskyButton = FindViewById<Button>(Resource.Id.add_whisky_button);
			AddWhiskyButton.Click += delegate {
				addWhisky();
			};
		}

		private void ShowCurrentRatingValue(int ResourceId, float Rating)
		{
			TextView textView = FindViewById<TextView>(ResourceId);
			textView.Text = Rating.ToString() + "/5";
		}

		private void CreateRatingBarsListeners()
		{
			FindViewById<RatingBar>(Resource.Id.smellRatingBar).RatingBarChange += (o, e) =>
			{
				ShowCurrentRatingValue(Resource.Id.whisky_smell_rate, e.Rating);
			};
			FindViewById<RatingBar>(Resource.Id.tasteRatingBar).RatingBarChange += (o, e) =>
			{
				ShowCurrentRatingValue(Resource.Id.whisky_taste_rate, e.Rating);
			};
			FindViewById<RatingBar>(Resource.Id.balansRatingBar).RatingBarChange += (o, e) =>
			{
				ShowCurrentRatingValue(Resource.Id.whisky_balans_rate, e.Rating);
			};
			FindViewById<RatingBar>(Resource.Id.finishRatingBar).RatingBarChange += (o, e) =>
			{
				ShowCurrentRatingValue(Resource.Id.whisky_finish_rate, e.Rating);
			};
		}

		public void addWhisky()
		{
			TextInputEditText whiskyNameTextInput = FindViewById<TextInputEditText>(Resource.Id.whisky_name_text_input);
			string WhiskyName = whiskyNameTextInput.Text;

			RatingBar SmellRatingBar = FindViewById<RatingBar>(Resource.Id.smellRatingBar);
			float SmellRating = SmellRatingBar.Rating;

			RatingBar TasteRatingBar = FindViewById<RatingBar>(Resource.Id.tasteRatingBar);
			float TasteRating = TasteRatingBar.Rating;

			RatingBar BalansRatingBar = FindViewById<RatingBar>(Resource.Id.balansRatingBar);
			float BalansRating = BalansRatingBar.Rating;

			RatingBar FinishRatingBar = FindViewById<RatingBar>(Resource.Id.finishRatingBar);
			float FinishRating = FinishRatingBar.Rating;

			if(!DataValidator.ValidateWhiskyName(WhiskyName))
			{
				
			}


			Whisky whisky = new Whisky(WhiskyName)
			{
				Smell = SmellRating,
				Taste = TasteRating,
				Balans = BalansRating,
				Finish = FinishRating
			};


			string path = Application.Context.FilesDir.Path;
			var filePath = Path.Combine(path, WhiskyListFileName);
			
			if (!File.Exists(filePath))
			{
				using (StreamWriter sw = File.CreateText(filePath))
				{
					sw.WriteLine(whisky.Name);
				}
			}
			else
			{
				using (StreamWriter sw = File.AppendText(filePath))
				{
					sw.WriteLine(whisky.Name);
				}
			}
			
			using (StreamReader sr = File.OpenText(filePath))
			{
				string s = "";
				while ((s = sr.ReadLine()) != null)
				{
					Console.WriteLine(s);
				}
			}
		}
	}

}