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

        public void DeletePlayerSetup(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e);
            DeleteCharacter();
            DeletePlayer();
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
				try
				{
                    command.Parameters.AddWithValue("@PlayerID", (pID.Text));
                    command.Parameters.AddWithValue("@PlayerName", PlayerNameBox.Text);
                    command.Parameters.AddWithValue("@Store", Gameid.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
				catch (System.Data.SqlClient.SqlException er)
				{
                    string error = "Error When Updating/Creating Character: ";
                    error += er.Message;
                    throw new Exception(error);
                }
				finally
				{
                    connection.Close();
                }
            }
        }

        //What will happen if we delete a player? Will this cause issues with already
        //existing characters that are assigned a playerID?

        //Deletes player (after character associated is removed)
        public void DeletePlayer()
        {
            //Test for deleting as well as incorporating try catch exceptions
            //We must handle all exceptions for credit
            string deleteQuery = "DELETE FROM Player Where PlayerID = @ID";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(deleteQuery, con))
            {
                try
                {
                    command.Parameters.AddWithValue("@ID", pID.Text);
                    command.CommandType = CommandType.Text;
                    con.Open();
                    command.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    string error = "Error When Deleting Player: ";
                    error += er.Message;
                    throw new Exception(error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        //Deletes character but retains playerID and gameID
        public void DeleteCharacter()
        {
            //Test for deleting as well as incorporating try catch exceptions
            //We must handle all exceptions for credit
            string deleteQuery = "DELETE FROM Character Where PlayerID = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(deleteQuery, con))
            {
                try
                {
                    command.Parameters.AddWithValue("@id", pID.Text);
                    command.CommandType = CommandType.Text;
                    con.Open();
                    command.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    string error = "Error When Deleting Player: ";
                    error += er.Message;
                    throw new Exception(error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "backFromPlayerSetup" || b.Name == "deletePlayerButton")
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
