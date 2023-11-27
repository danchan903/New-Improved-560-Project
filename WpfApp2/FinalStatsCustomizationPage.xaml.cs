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
	/// Interaction logic for FinalStatsCustomizationPage.xaml
	/// </summary>
	public partial class FinalStatsCustomizationPage : UserControl
	{
        SqlConnection connection;
        string connectionString;

        public FinalStatsCustomizationPage()
		{
			DataContext = this;
			InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

		public event EventHandler<CustomButtonEventArgs> backToCharacterCustomization;
		public event EventHandler<CustomButtonEventArgs> confirmToCharacterCustomization;


		public void ClickConfirmButton(object sender, RoutedEventArgs e)
		{

			ButtonClick(sender, e);

			string strengthQuery = "INSERT INTO ListCharacterStats VALUES (1, 1, @Strength)";
            string dexterityQuery = "INSERT INTO ListCharacterStats VALUES (1, 2, @Dexterity)";
            string constitutionQuery = "INSERT INTO ListCharacterStats VALUES (1, 3, @Constitution)";
            string intelligenceQuery = "INSERT INTO ListCharacterStats VALUES (1, 4, @Intelligence)";
            string wisdomQuery = "INSERT INTO ListCharacterStats VALUES (1, 5, @Wisdom)";
            string charismaQuery = "INSERT INTO ListCharacterStats VALUES (1, 6, @Charisma)";

			using (connection = new SqlConnection(connectionString))
			using (SqlCommand command = new SqlCommand(strengthQuery, connection))
			{
				connection.Open();
				command.Parameters.AddWithValue("@Strength", str.Text);
				command.ExecuteScalar();
            }

			using (connection = new SqlConnection(connectionString))
			using (SqlCommand command = new SqlCommand(dexterityQuery, connection))
			{
				connection.Open();
                command.Parameters.AddWithValue("@Dexterity", dex.Text);
                command.ExecuteScalar();
            }

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(constitutionQuery, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Constitution", cons.Text);
                command.ExecuteScalar();
            }

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(intelligenceQuery, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Intelligence", inte.Text);
                command.ExecuteScalar();
            }

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(wisdomQuery, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Wisdom", wis.Text);
                command.ExecuteScalar();
            }

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(charismaQuery, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Charisma", chari.Text);
                command.ExecuteScalar();
            }

        }


		public void ClickBackButton(object sender, RoutedEventArgs e)
		{

			ButtonClick(sender, e);

		}


		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "BackButton")
				{
					backToCharacterCustomization?.Invoke(this, new CustomButtonEventArgs("BackToCharacterCustomizationFromStats"));
				}

				if (b.Name == "ConfirmButton")
				{
					confirmToCharacterCustomization?.Invoke(this, new CustomButtonEventArgs("ConfirmToCharacterCustomizationFromStats"));
				}



			}
		}
	}
}
