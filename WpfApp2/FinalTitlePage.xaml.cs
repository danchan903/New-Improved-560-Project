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
	/// Interaction logic for FinalTitlePage.xaml
	/// </summary>
	public partial class FinalTitlePage : UserControl
	{
		public FinalTitlePage()
		{
			InitializeComponent();
			DataContext = this;

		}
		public event EventHandler<CustomButtonEventArgs> addCharacterToGameEvent;
		public event EventHandler<CustomButtonEventArgs> createNewGameEvent;
		public event EventHandler<CustomButtonEventArgs> newPlayerEvent;








		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "AddNewCharacterToGameButton")
				{
					addCharacterToGameEvent?.Invoke(this, new CustomButtonEventArgs("GoToAddCharacter"));
				}

				if (b.Name == "CreateNewGameButton")
				{
					createNewGameEvent?.Invoke(this, new CustomButtonEventArgs("GoToCreateNewGame"));
				}
				if (b.Name == "RegisterNewPlayerButton")
				{
					newPlayerEvent?.Invoke(this, new CustomButtonEventArgs("GoToRegisterNewPlayer"));
				}



			}
		}



		/// <summary>
		/// This is what happens when the Create New Character button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AddNewCharacterToGameClick(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);
		}

		/// <summary>
		/// This is what happens when the Create New Game button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void CreateNewGameButtonClick(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		/// <summary>
		/// This is what happens when the Register New Player button is pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void RegisterNewPlayerClick(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}
	}
}
