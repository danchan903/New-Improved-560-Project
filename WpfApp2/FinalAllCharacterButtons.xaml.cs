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
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Collections;

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for FinalAllCharacterButtons.xaml
	/// </summary>
	public partial class FinalAllCharacterButtons : UserControl
	{
		SqlConnection connection;
		string connectionString;

		public static string className { get; set; }
		public static string currentRace { get; set; }

		public static List<string> allItemsOwned { get; set; }

		public FinalAllCharacterButtons()
		{
			InitializeComponent();

			connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
		}

/*		private void FinalAllCharacterButtons_Load(object sender, EventArgs e)
		{
			PopulateCharacterTable();
		}

        private void PopulateCharacterTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Recipe", connection))
            {
                DataTable characterTable = new DataTable();
                adapter.Fill(characterTable);

                *//*
				 * listviewName.DisplayMember = "Name";
				 * listviewName.ValueMember = "id";
				 * listviewName.DataSource = characterTable;
				 *//*
            }
        }

        private void PopulateCharacterTableWithQuery()
		{
			string query = "SELECT a.Name FROM FROM Ingredient a " +
				"INNER JOIN RecipeIngredient b ON a.ID = b.IngredientId " +
				"WHERE b.RecipeID = @RecipeId";

			using (connection = new SqlConnection(connectionString))
			using (SqlCommand command = new SqlCommand(query, connection))
			using (SqlDataAdapter adapter = new SqlDataAdapter(command))
			{
				command.Parameters.AddWithValue("@RecipeId", listviewName.SelectedValue);

				DataTable characterTable = new DataTable();
				adapter.Fill(characterTable);

				*//*
				 * listviewName.DisplayMember = "Name";
				 * listviewName.ValueMember = "id";
				 * listviewName.DataSource = characterTable;
				 *//*
			}
		}*/

/*		private void listview_SelectedIndexChanged(object sender, EventArgs e)
		{
			PopulateCharacterTableWithQuery();
		}*/

		public event EventHandler<CustomButtonEventArgs> toEditClass;
		public event EventHandler<CustomButtonEventArgs> toEditStats;
		public event EventHandler<CustomButtonEventArgs> toEditRace;
		public event EventHandler<CustomButtonEventArgs> toEditInventory;
		public event EventHandler<CustomButtonEventArgs> backToMainMenuFromCharacterCreation;
		public event EventHandler<CustomButtonEventArgs> confirmToMainMenuFromCharacterCreation;


		public void ConfirmCharacterInfo(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);
			UpdateAndInsert();

		}

		public void UpdateAndInsert()
		{
            string query = @"IF EXISTS(SELECT * FROM Character WHERE CharacterName = @Name)
				UPDATE Character SET CharacterDescription = @Description, RaceID = @Race, ClassID = @Class,
				PlayerID = @Player, GameID = @Game WHERE CharacterName = @Name
				ELSE INSERT INTO Character(CharacterName, CharacterDescription, RaceID, ClassID, 
				PlayerID, GameID) VALUES(@Name, @Description, @Race, @Class, @Player, @Game)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", CharacterName.Text);
                command.Parameters.AddWithValue("@Description", CharacterName.Text); ///////////////FIX THIS WHEN TEXT BOX IS THERE
                command.Parameters.AddWithValue("@Race", GetRaceID());
                command.Parameters.AddWithValue("@Class", GetClassID());
                command.Parameters.AddWithValue("@Player", Convert.ToInt32(PlayerID.Text));
                command.Parameters.AddWithValue("@Game", Convert.ToInt32(GameID.Text));
                CharacterName.Clear();
                PlayerID.Clear();
                GameID.Clear();
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            /*            string query = "INSERT INTO Character VALUES (@CharacterName, @CharacterDescription, @RaceID, @ClassID, @PlayerID, @GameID)";

						using (connection = new SqlConnection(connectionString))
						using (SqlCommand command = new SqlCommand(query, connection))
						{


							connection.Open();
							command.Parameters.AddWithValue("@CharacterName", CharacterName.Text);
							command.Parameters.AddWithValue("@CharacterDescription", CharacterName.Text); ///////////////FIX THIS WHEN TEXT BOX IS THERE
							command.Parameters.AddWithValue("@RaceID", GetRaceID());
							command.Parameters.AddWithValue("@ClassID", GetClassID());
							command.Parameters.AddWithValue("@PlayerID", Convert.ToInt32(PlayerID.Text));
							command.Parameters.AddWithValue("@GameID", Convert.ToInt32(GameID.Text));
							CharacterName.Clear();
							PlayerID.Clear();
							GameID.Clear();


							command.ExecuteScalar();
						}
			*/
        }

		public void DeleteCharacter()
		{
            //Test for deleting as well as incorporating try catch exceptions
            //We must handle all exceptions for credit
            string deleteQuery = "DELETE FROM Character Where CharacterName = @Name";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                try
                {
                    con.Open();
                    command.Parameters.AddWithValue("@Name", CharacterName);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException er)
                {
                    string error = "Error When Deleting Character: ";
                    error += er.Message;
                    throw new Exception(error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int GetRaceID()
		{
			if (currentRace.Contains("Dragonborn")) return 1;
			else if (currentRace.Contains("Dwarf")) return 2;
			else if (currentRace.Contains("Gnome")) return 4;
			else if (currentRace.Contains("Half-Elf")) return 5;
			else if (currentRace.Contains("Elf")) return 3;
			else if (currentRace.Contains("Halfling")) return 6;
			else if (currentRace.Contains("Half-Orc")) return 7;
			else if (currentRace.Contains("Human")) return 8;
			else return 9; //Tiefling

		}

		public int GetClassID()
		{
			if (className.Contains("Barbarian")) return 1;
			else if (className.Contains("Bard")) return 2;
			else if (className.Contains("Cleric")) return 3;
			else if (className.Contains("Druid")) return 4;
			else if (className.Contains("Fighter")) return 5;
			else if (className.Contains("Monk")) return 6;
			else if (className.Contains("Paladin")) return 7;
			else if (className.Contains("Ranger")) return 8;
			else if (className.Contains("Rogue")) return 9;
			else if (className.Contains("Sorcerer")) return 10;
			else if (className.Contains("Warlock")) return 11;
			else return 12; //Wizard

		}

		public void GoToEditInventory(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);
		}

		public void GoToEditClass(object sender, RoutedEventArgs e)
		{
            ButtonClick(sender, e);
		}

		public void GoToRaceControl(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);
		}

		public void GoToCharacterStats(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void BackToMainMenuFromCharacterCreation(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "BackButtonInCharacterCreation")
				{
					backToMainMenuFromCharacterCreation?.Invoke(this, new CustomButtonEventArgs("BackToMainFromCharacterCreation"));
				}

				if (b.Name == "ConfirmCharacterInfoButton")
				{

					confirmToMainMenuFromCharacterCreation?.Invoke(this, new CustomButtonEventArgs("ConfirmToMainFromCharacterCreation"));
				}
				if (b.Name == "EditCharacterClassButton")
				{
					toEditClass?.Invoke(this, new CustomButtonEventArgs("ToEditCharacterClass"));
				}
				if (b.Name == "EditCharacterInventoryButton")
				{
					toEditInventory?.Invoke(this, new CustomButtonEventArgs("ToEditCharacterInventory"));
				}
				if (b.Name == "EditCharacterRaceButton")
				{
					toEditRace?.Invoke(this, new CustomButtonEventArgs("ToEditCharacterRace"));
				}
				if (b.Name == "EditCharacterStatsButton")
				{
					toEditStats?.Invoke(this, new CustomButtonEventArgs("ToEditCharacterStats"));
				}

			}
		}
	}
}
