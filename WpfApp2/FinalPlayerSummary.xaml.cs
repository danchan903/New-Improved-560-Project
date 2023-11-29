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
	/// Interaction logic for FinalPlayerSummary.xaml
	/// </summary>
	public partial class FinalPlayerSummary : UserControl
	{
        SqlConnection connection;
        string connectionString;

        public FinalPlayerSummary()
		{
			InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
            PopulatePlayerTable();
		}

		public event EventHandler<CustomButtonEventArgs> backToMainMenuFromPlayerSummary;

		public void ClickBackInPlayerSummary(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

/*		private void ComboBoxChanged(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (ComboForPlayerSummary != null)
			{
				ComboForPlayerSummary = (ComboBox)e.Control;
			}
		}*/

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

        private void PopulatePlayerTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Player", connection))
            {
                DataTable playerTable = new DataTable();
                adapter.Fill(playerTable);

                ComboForPlayerSummary.DisplayMemberPath = "PlayerName";
                ComboForPlayerSummary.SelectedValuePath = "PlayerName";
                ComboForPlayerSummary.ItemsSource = playerTable.DefaultView;
            }
        }

/*		private void FillGrid()
		{
			using (connection = new SqlConnection(connectionString))
			using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT p.PlayerName, c.CharacterName, g.GameStartDate, " +
				"g.GameID, g.GameDescription FROM Player INNER JOIN [Character] c ON p.PlayerID = c.PlayerID INNER JOIN Game " +
				"g ON c.GameID = g.GameID GROUP BY p.PlayerName, g.GameStartDate, c.CharacterName, g.GameID, g.GameDescription " +
				"ORDER BY g.GameStartDate ASC", connection))
			{
				DataTable table = new DataTable();
				adapter.Fill(table);
				PlayerSummaryOutput.ItemsSource = table.DefaultView;
			}
		}*/

    }
}
