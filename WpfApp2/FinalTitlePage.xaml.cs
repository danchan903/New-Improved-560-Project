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
		public event EventHandler<CustomButtonEventArgs> playerSummaryClickEvent;
		public event EventHandler<CustomButtonEventArgs> gameSummaryClickEvent;
		public event EventHandler<CustomButtonEventArgs> classSummaryClickEvent;
		public event EventHandler<CustomButtonEventArgs> highestStatsClickEvent;








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
				if (b.Name == "PlayerSummaryButton")
				{
					playerSummaryClickEvent?.Invoke(this, new CustomButtonEventArgs("GoToPlayerSummary"));
				}
				if (b.Name == "GameSummaryButton")
				{
					gameSummaryClickEvent?.Invoke(this, new CustomButtonEventArgs("GoToGameSummary"));
				}
				if (b.Name == "ClassSummaryButton")
				{
					classSummaryClickEvent?.Invoke(this, new CustomButtonEventArgs("GoToClassSummary"));
				}
				if (b.Name == "HighestStatsButton")
				{
					highestStatsClickEvent?.Invoke(this, new CustomButtonEventArgs("GoToHighestStats"));
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

		public void PlayerSummaryClick(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void GameSummaryClick(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ClassSummaryClick(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void HighestStatsClick(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}
	}
}
