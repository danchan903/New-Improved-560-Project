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
	/// Interaction logic for FinalAllCharacterButtons.xaml
	/// </summary>
	public partial class FinalAllCharacterButtons : UserControl
	{
		SqlConnection connection;
		string connectionString;

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

/*            string query = "SELECT a.Name FROM FROM Ingredient a " +
                "INNER JOIN RecipeIngredient b ON a.ID = b.IngredientId " +
                "WHERE b.RecipeID = @RecipeId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@RecipeId", listviewName.SelectedValue);

                DataTable characterTable = new DataTable();
                adapter.Fill(characterTable);

                listviewName.DisplayMember = "Name";
                listviewName.ValueMember = "id";
                listviewName.DataSource = characterTable;*/
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
