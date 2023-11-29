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
        SqlConnection connection;
        string connectionString;

        public FinalPlayerCreation()
		{
			InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
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

            string query = @"IF EXISTS(SELECT * FROM Player WHERE PlayerID = @PlayerID)
				UPDATE Player SET PlayerName = @PlayerName, GameStoreID = @Store WHERE PlayerID = @PlayerID
				ELSE INSERT INTO Player(PlayerID, PlayerName, GameStoreID) VALUES(@PlayerID, @PlayerName, @Store)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PlayerID", (pID.Text));
                command.Parameters.AddWithValue("@PlayerName", PlayerNameBox.Text);
                command.Parameters.AddWithValue("@Store", Gameid.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
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
