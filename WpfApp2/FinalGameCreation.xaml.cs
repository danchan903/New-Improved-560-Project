﻿using System;
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
	/// Interaction logic for FinalGameCreation.xaml
	/// </summary>
	public partial class FinalGameCreation : UserControl
	{
        SqlConnection connection;
        string connectionString;

        public FinalGameCreation()
		{
			InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

		public event EventHandler<CustomButtonEventArgs> backToMainMenuFromGameCreation;
		public event EventHandler<CustomButtonEventArgs> confirmToMainMenuFromGameCreation;

		public void ClickBackInGameCreator(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ClickConfirmInGameCreator(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

/*			int id;
			string query;
			bool flag = false;*/

			string query = @"IF EXISTS(SELECT * FROM Game WHERE GameID = @GameID)
				UPDATE Game SET GameDescription = @Description, GameStartDate = @Date WHERE GameID = @GameID
				ELSE INSERT INTO Game(GameID, GameDescription, GameStartDate) VALUES(@GameID, @Description, @Date)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			using (SqlCommand command = new SqlCommand(query, connection))
			{
				try
				{
                    command.Parameters.AddWithValue("@GameID", Int32.Parse(ID.Text));
                    command.Parameters.AddWithValue("@Description", Description.Text);
                    command.Parameters.AddWithValue("@Date", Date.Text);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    string error = "Error When Updating/Creating Game: ";
                    error += er.Message;
                    throw new Exception(error);
                }
                finally 
				{
                    connection.Close();
                }
            }

            /*if (flag == false)
			{
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT @GameID"))
                {
                    SqlDataReader search = command.ExecuteReader();
                    while (search.Read())
                    {
                        id = search.GetInt32(0);
						if (id == Int32.Parse(ID.Text))
						{
							query = "UPDATE Game SET GameID = @GameID WHERE @GameID";
							connection.Open();
							command.Parameters.AddWithValue("@GameID", Int32.Parse(ID.Text));
                            command.Parameters.AddWithValue("@Description", Description.Text);
                            command.Parameters.AddWithValue("@Date", Date.Text);
							command.ExecuteScalar();
                        }
						else
						{
							flag = true;
						}
                    }
                }
            }

			else
			{
                query = "INSERT INTO Game VALUES (@GameID, @Description, @Date)";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@GameID", Int32.Parse(ID.Text));
                    command.Parameters.AddWithValue("@Description", Description.Text);
                    command.Parameters.AddWithValue("@Date", Date.Text);
                    command.ExecuteScalar();
                }
            }*/
        }

        //What will happen if we delete a game? Will these cause issues with already
        //existing games?
/*        public void DeleteGame()
        {
            //Test for deleting as well as incorporating try catch exceptions
            //We must handle all exceptions for credit
            string deleteQuery = "DELETE FROM Game Where GameID = @ID)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(deleteQuery, con))
            {
                try
                {
                    command.Parameters.AddWithValue("@ID", Int32.Parse(ID.Text));
                    command.CommandType = CommandType.Text;
                    con.Open();
                    command.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    string error = "Error When Deleting Game: ";
                    error += er.Message;
                    throw new Exception(error);
                }
                finally
                {
                    con.Close();
                }
            }
        }*/

        public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "backFromGameCreator")
				{
					backToMainMenuFromGameCreation?.Invoke(this, new CustomButtonEventArgs("BackToMainMenuFromGameCreator"));
				}

				if (b.Name == "confirmFromGameCreator")
				{
					confirmToMainMenuFromGameCreation?.Invoke(this, new CustomButtonEventArgs("ConfirmToMainmenuFromGameCreator"));
				}

			}
		}
	}
}
