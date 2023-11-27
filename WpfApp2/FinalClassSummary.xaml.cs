﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for FinalClassSummary.xaml
	/// </summary>
	public partial class FinalClassSummary : UserControl
	{
		public FinalClassSummary()
		{
			InitializeComponent();
		}
		public event EventHandler<CustomButtonEventArgs> backToMainMenuFromClassSummary;

		public void ClickBackInClassSummary(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "backFromClassSummary")
				{
					backToMainMenuFromClassSummary?.Invoke(this, new CustomButtonEventArgs("BackToMainMenuFromClassSummary"));
				}


			}
		}


	}
}
