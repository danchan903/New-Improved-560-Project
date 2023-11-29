using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for FinalSpellCustomization.xaml
    /// </summary>
    public partial class FinalSpellCustomization : UserControl
    {
        public FinalSpellCustomization()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
            PopulateSpellsTable();
        }

        SqlConnection connection;
        string connectionString;

        public event EventHandler<CustomButtonEventArgs> backToCharacterCreatorFromSpell;
        public event EventHandler<CustomButtonEventArgs> confirmToCharacterCreatorFromSpell;

        public ObservableCollection<string> Spells { get; }

        public void BackToCharacterCreationFromSpell(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e);

        }

        public void ConfirmToCharacterCreationFromSpell(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e);

        }

        public void ButtonClick(object sender, RoutedEventArgs e)
        {

            if (sender is Button b)
            {
                if (b.Name == "BackButtonFromSpell")
                {
                    backToCharacterCreatorFromSpell?.Invoke(this, new CustomButtonEventArgs("BackToCharacterCreationFromInventory"));
                }

                if (b.Name == "ConfirmButtonFromSpell")
                {
                    confirmToCharacterCreatorFromSpell?.Invoke(this, new CustomButtonEventArgs("ConfirmToCharacterCreationFromInventory"));
                    FinalAllCharacterButtons.spell = SpellBox.Text;
                }

            }
        }

        private void PopulateSpellsTable()
        {
            /*            string query = @"IF EXISTS (SELECT * FROM Spells s INNER JOIN " +
                            "Class c ON s.ClassID = c.ClassID WHERE ClassID = @id) ELSE SELECT * FROM Spells";*/
            string query = "SELECT * FROM Spells";
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable t = new DataTable();
                adapter.Fill(t);

                SpellBox.DisplayMemberPath = "Name";
                SpellBox.SelectedValuePath = "Name";

                SpellBox.ItemsSource = t.DefaultView;
            }
        }
    }
}
