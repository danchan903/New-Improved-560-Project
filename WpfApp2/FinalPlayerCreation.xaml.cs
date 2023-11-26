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
	/// Interaction logic for FinalPlayerCreation.xaml
	/// </summary>
	public partial class FinalPlayerCreation : UserControl
	{
		public FinalPlayerCreation()
		{
			InitializeComponent();
		}

		public event EventHandler<CustomButtonEventArgs> backToMainMenuFromPlayerCreator;
		public event EventHandler<CustomButtonEventArgs> confirmToMainMenuFromPlayerCreator;

		public void ClickBackInPlayerSetup(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ClickConfirmInPlayerSetup(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "backFromPlayerSetup")
				{
					backToMainMenuFromPlayerCreator?.Invoke(this, new CustomButtonEventArgs("BackToMainMenuFromPlayerCreator"));
				}

				if (b.Name == "confirmFromPlayerSetup")
				{
					confirmToMainMenuFromPlayerCreator?.Invoke(this, new CustomButtonEventArgs("ConfirmToMainmenuFromPlayerCreator"));
				}

			}
		}
	}
}
