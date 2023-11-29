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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;

			TitlePageControl.addCharacterToGameEvent += OnButtonClick;
			TitlePageControl.createNewGameEvent += OnButtonClick;
			TitlePageControl.newPlayerEvent += OnButtonClick;
			StatsCustomControl.backToCharacterCustomization += OnButtonClick;
			StatsCustomControl.confirmToCharacterCustomization += OnButtonClick;
			CharacterCreationControl.toEditStats += OnButtonClick;
			CharacterCreationControl.toEditClass += OnButtonClick;
			CharacterCreationControl.toEditInventory += OnButtonClick;
			CharacterCreationControl.toEditRace += OnButtonClick;
			CharacterCreationControl.backToMainMenuFromCharacterCreation += OnButtonClick;
			CharacterCreationControl.confirmToMainMenuFromCharacterCreation += OnButtonClick;
			ClassCustomizationControl.backToCharacterCreatorFromClass += OnButtonClick;
			ClassCustomizationControl.confirmToCharacterCreatorFromClass += OnButtonClick;
			RaceControl.backToCharacterCreatorFromRace += OnButtonClick;
			RaceControl.confirmToCharacterCreatorFromRace += OnButtonClick;
			ItemCustomizationControl.backToCharacterCreatorFromInventory += OnButtonClick;
			ItemCustomizationControl.confirmToCharacterCreatorFromInventory += OnButtonClick;
			GameCreationControl.backToMainMenuFromGameCreation += OnButtonClick;
			GameCreationControl.confirmToMainMenuFromGameCreation += OnButtonClick;
			PlayerCreationControl.backToMainMenuFromPlayerCreator += OnButtonClick;
			PlayerCreationControl.confirmToMainMenuFromPlayerCreator += OnButtonClick;
			TitlePageControl.playerSummaryClickEvent += OnButtonClick;
			TitlePageControl.gameSummaryClickEvent += OnButtonClick;
			TitlePageControl.classSummaryClickEvent += OnButtonClick;
			TitlePageControl.highestStatsClickEvent += OnButtonClick;
			ClassSummaryControl.backToMainMenuFromClassSummary += OnButtonClick;
			GameSummaryControl.backToMainMenuFromGameSummary += OnButtonClick;
			PlayerSummaryControl.backToMainMenuFromPlayerSummary += OnButtonClick;
			HighestStatsControl.backToMainMenuFromStatsSummary += OnButtonClick;
		}

		private void OnButtonClick(object sender, CustomButtonEventArgs e)
		{



			if (e.Label == "GoToAddCharacter")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;
			}

			if (e.Label == "GoToCreateNewGame")
			{
				EverythingHidden();
				GameCreationControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "GoToRegisterNewPlayer")
			{
				EverythingHidden();
				PlayerCreationControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "BackToCharacterCustomizationFromStats")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ConfirmToCharacterCustomizationFromStats")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "BackToMainFromCharacterCreation")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ConfirmToMainFromCharacterCreation")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "ToEditCharacterClass")
			{
				EverythingHidden();
				ClassCustomizationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ToEditCharacterInventory")
			{
				EverythingHidden();
				ItemCustomizationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ToEditCharacterRace")
			{
				EverythingHidden();
				RaceControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ToEditCharacterStats")
			{
				EverythingHidden();
				StatsCustomControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "BackToCharacterCreationFromClass")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ConfirmToCharacterCreationFromClass")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "BackToCharacterCreationFromRace")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ConfirmToCharacterCreationFromRace")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "BackToCharacterCreationFromInventory")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ConfirmToCharacterCreationFromInventory")
			{
				EverythingHidden();
				CharacterCreationControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "BackToMainMenuFromGameCreator")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ConfirmToMainmenuFromGameCreator")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "BackToMainMenuFromPlayerCreator")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "ConfirmToMainmenuFromPlayerCreator")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;

			}
			if (e.Label == "GoToPlayerSummary")
			{
				EverythingHidden();
				PlayerSummaryControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "GoToGameSummary")
			{
				EverythingHidden();
				GameSummaryControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "GoToClassSummary")
			{
				EverythingHidden();
				ClassSummaryControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "GoToHighestStats")
			{
				EverythingHidden();
				HighestStatsControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "BackToMainMenuFromClassSummary")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "BackToMainMenuFromGameSummary")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "BackToMainMenuFromPlayerSummary")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;
			}
			if (e.Label == "BackToMainMenuFromStatsSummary")
			{
				EverythingHidden();
				TitlePageControl.Visibility = Visibility.Visible;
			}

		}


		private void EverythingHidden()
		{
			TitlePageControl.Visibility = Visibility.Hidden;
			StatsCustomControl.Visibility = Visibility.Hidden;
			RaceControl.Visibility = Visibility.Hidden;
			PlayerCreationControl.Visibility = Visibility.Hidden;
			ItemCustomizationControl.Visibility = Visibility.Hidden;
			GameCreationControl.Visibility = Visibility.Hidden;
			ClassCustomizationControl.Visibility = Visibility.Hidden;
			CharacterCreationControl.Visibility = Visibility.Hidden;
			PlayerSummaryControl.Visibility = Visibility.Hidden;
			GameSummaryControl.Visibility = Visibility.Hidden;
			ClassSummaryControl.Visibility = Visibility.Hidden;
			HighestStatsControl.Visibility = Visibility.Hidden;
		}
	}
}
