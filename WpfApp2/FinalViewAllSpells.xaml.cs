using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for FinalViewAllSpells.xaml
    /// </summary>
    public partial class FinalViewAllSpells : UserControl
    {

        SqlConnection connection;
        string connectionString;

        public FinalViewAllSpells()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
            PopulateSpellsTable();
        }

        public event EventHandler<CustomButtonEventArgs> backToMainMenuFromAllSpells;

        public void ClickBackInAllSpells(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e);

        }

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                if (b.Name == "backFromAllSpells")
                {
                    backToMainMenuFromAllSpells?.Invoke(this, new CustomButtonEventArgs("BackToMainMenuFromAllSpells"));
                }
            }
        }

        public void PopulateSpellsTable()
        {
            //string query = @"SELECT * FROM Spells Where ClassID = @id";
            string query = @"SELECT * FROM Spells";
            using (connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            //using (SqlCommand command = new SqlCommand("@ClassID", connection))
            {
                //connection.Open();
                //command.Parameters.AddWithValue("@ClassID", FinalAllCharacterButtons.ClassID);

                 DataTable t = new DataTable();
                 adapter.Fill(t);
         
                 AllSpellsOutput.DisplayMemberPath = "Name";
                 AllSpellsOutput.SelectedValuePath = "Name";

                 AllSpellsOutput.ItemsSource = t.DefaultView;
                 //command.ExecuteScalar();
/*                command.Parameters.AddWithValue("@id", FinalAllCharacterButtons.ClassID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();*/
            }
        }

    }
}
