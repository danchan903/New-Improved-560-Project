using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
	public class CustomButtonEventArgs : RoutedEventArgs
	{

		public CustomButtonEventArgs(string title)
		{
			Label = title;

		}
		public string Label { get; set; }



	}
}
