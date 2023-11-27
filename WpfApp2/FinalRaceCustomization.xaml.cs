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
using System.Data;

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for FinalRaceCustomization.xaml
	/// </summary>
	public partial class FinalRaceCustomization : UserControl
    {
        SqlConnection connection;
        string connectionString;

        public FinalRaceCustomization()
		{
			InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
            PopulateRaceTable();
        }
		public event EventHandler<CustomButtonEventArgs> backToCharacterCreatorFromRace;
		public event EventHandler<CustomButtonEventArgs> confirmToCharacterCreatorFromRace;


		public void ClickBackButton(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ConfirmBackButton(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "BackToCharacterCreationFromRace")
				{
					backToCharacterCreatorFromRace?.Invoke(this, new CustomButtonEventArgs("BackToCharacterCreationFromRace"));
				}

				if (b.Name == "ConfirmToCharacterCreationFromRace")
				{
					confirmToCharacterCreatorFromRace?.Invoke(this, new CustomButtonEventArgs("ConfirmToCharacterCreationFromRace"));
				}

			}
		}

        private void PopulateRaceTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Race", connection))
            {
                DataTable raceTable = new DataTable();
                adapter.Fill(raceTable);

                racesbox.DisplayMemberPath = "RaceName";
                racesbox.SelectedValuePath = "RaceName";
                racesbox.ItemsSource = raceTable.DefaultView;
            }
        }

    }
}
