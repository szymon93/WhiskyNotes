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

namespace WhiskyNotes.Classes.AddWhisky
{
	public class Whisky
	{
		public string Name { get; set; }
		public float Smell { get; set; }
		public float Taste { get; set; }
		public float Balans { get; set; }
		public float Finish { get; set; }
		public BottlePhoto BottlePhote { get; set; }

		public Whisky(string Name)
		{
			this.Name = Name;
		}

		
	}
}