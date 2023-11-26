using System;
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
using System.Configuration;
using System.Data.SqlClient;

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for FinalStatsCustomizationPage.xaml
	/// </summary>
	public partial class FinalStatsCustomizationPage : UserControl
	{
		public FinalStatsCustomizationPage()
		{
			DataContext = this;
			InitializeComponent();
		}

		public event EventHandler<CustomButtonEventArgs> backToCharacterCustomization;
		public event EventHandler<CustomButtonEventArgs> confirmToCharacterCustomization;


		public void ClickConfirmButton(object sender, RoutedEventArgs e)
		{

			ButtonClick(sender, e);


		}


		public void ClickBackButton(object sender, RoutedEventArgs e)
		{

			ButtonClick(sender, e);

		}


		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "BackButton")
				{
					backToCharacterCustomization?.Invoke(this, new CustomButtonEventArgs("BackToCharacterCustomizationFromStats"));
				}

				if (b.Name == "ConfirmButton")
				{
					confirmToCharacterCustomization?.Invoke(this, new CustomButtonEventArgs("ConfirmToCharacterCustomizationFromStats"));
				}



			}
		}
	}
}
