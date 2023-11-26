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
	/// Interaction logic for FinalGameCreation.xaml
	/// </summary>
	public partial class FinalGameCreation : UserControl
	{
		public FinalGameCreation()
		{
			InitializeComponent();
		}

		public event EventHandler<CustomButtonEventArgs> backToMainMenuFromGameCreation;
		public event EventHandler<CustomButtonEventArgs> confirmToMainMenuFromGameCreation;

		public void ClickBackInGameCreator(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ClickConfirmInGameCreator(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "backFromGameCreator")
				{
					backToMainMenuFromGameCreation?.Invoke(this, new CustomButtonEventArgs("BackToMainMenuFromGameCreator"));
				}

				if (b.Name == "confirmFromGameCreator")
				{
					confirmToMainMenuFromGameCreation?.Invoke(this, new CustomButtonEventArgs("ConfirmToMainmenuFromGameCreator"));
				}

			}
		}
	}
}
