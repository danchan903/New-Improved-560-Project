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

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for FinalPlayerSummary.xaml
	/// </summary>
	public partial class FinalPlayerSummary : UserControl
	{
		public FinalPlayerSummary()
		{
			InitializeComponent();
		}

		public event EventHandler<CustomButtonEventArgs> backToMainMenuFromPlayerSummary;

		public void ClickBackInPlayerSummary(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "backFromPlayerSummary")
				{
					backToMainMenuFromPlayerSummary?.Invoke(this, new CustomButtonEventArgs("BackToMainMenuFromPlayerSummary"));
				}


			}
		}

	}
}
