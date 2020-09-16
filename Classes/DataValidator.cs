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

namespace WhiskyNotes.Classes
{
	public static class DataValidator
	{
		public static bool ValidateWhiskyName(string Name)
		{
			if(string.IsNullOrEmpty(Name))
			{
				return false;
			}

			return true;
		}
	}
}