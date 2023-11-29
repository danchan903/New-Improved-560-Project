using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
	/// Interaction logic for FinalHighestStats.xaml
	/// </summary>
	public partial class FinalHighestStats : UserControl
	{
        SqlConnection connection;
        string connectionString;

        public FinalHighestStats()
		{
			InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }


		public event EventHandler<CustomButtonEventArgs> backToMainMenuFromStatsSummary;

		public void ClickBackInStatsSummary(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "backFromStatsSummary")
				{
					backToMainMenuFromStatsSummary?.Invoke(this, new CustomButtonEventArgs("BackToMainMenuFromStatsSummary"));
				}


			}
		}

        private void PopulateGameSummaryTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ListCharacterStats ORDER BY ", connection))
            {
                DataTable playerTable = new DataTable();
                adapter.Fill(playerTable);

                GameSummaryOutput.DisplayMemberPath = "PlayerName";
                GameSummaryOutput.SelectedValuePath = "PlayerName";
                GameSummaryOutput.ItemsSource = playerTable.DefaultView;
            }
        }
    }
}
